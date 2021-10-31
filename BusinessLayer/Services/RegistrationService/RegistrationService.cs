using System;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.DTOs;
using BusinessLayer.Services.HashService;
using BusinessLayer.Services.SmtpService;
using Core.Models;
using DataLayer.EmailRepository;
using DataLayer.UserRepository;

namespace BusinessLayer.Services.RegistrationService
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailRepository _emailRepository;
        private readonly IHashService _hashService;
        private readonly ISmtpService _smtpService;

        public RegistrationService(IUserRepository userRepository,
            IMapper mapper,
            IHashService hashService,
            IEmailRepository emailRepository,
            ISmtpService smtpService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailRepository = emailRepository;
            _hashService = hashService;
            _smtpService = smtpService;
        }

        public async Task<bool> ConfirmEmailAsync(string email, string message)
        {
            var confirmationMessage = await _emailRepository.GetConfirmMessageAsync(email);
            var result = confirmationMessage == message;

            if (result)
            {
                await _emailRepository.ConfirmEmailAsync(email);
            }

            return result;
        }

        public async Task<Guid> RegisterUserAsync(AccountInfoDTO accountInfoDTO, string uri)
        {
            var confirmationMessage = Guid.NewGuid();
            int? emailId = null;

            if (!string.IsNullOrEmpty(accountInfoDTO.Email))
            {
                emailId = await SaveUserEmailAsync(accountInfoDTO.Email, confirmationMessage);
            }

            var result = await SaveUserInfoAsync(accountInfoDTO, emailId);

            if (emailId.HasValue)
            {
                await SendConfirmationEmailAsync(accountInfoDTO.Email, uri, confirmationMessage);
            }

            return result;
        }

        private async Task<int> SaveUserEmailAsync(string email, Guid confirmationMessage)
        {
            var mail = new Email
            {
                PostName = email,
                IsConfirmed = false,
                ConfirmationString = confirmationMessage.ToString()
            };

            return await _emailRepository.RegisterEmailAsync(mail);
        }

        private async Task<Guid> SaveUserInfoAsync(AccountInfoDTO accountInfoDTO, int? emailId)
        {
            var accountInfo = _mapper.Map<AccountInfo>(accountInfoDTO);
            accountInfo.EmailId = emailId.Value;
            accountInfo.LoginInfo.Password = _hashService.HashString(accountInfo.LoginInfo.Password);

            var result = await _userRepository.AddUserAsync(accountInfo);
            return result;
        }

        private async Task SendConfirmationEmailAsync(
            string email,
            string uri,
            Guid confirmationMessage)
        {
            var mailDTO = new MailDTO
            {
                To = email,
                Subject = "ITEA Email confirmation",
                Body = $"{uri}/accounts/" +
                $"confirm?email={email}" +
                $"&message={confirmationMessage}"
            };

            await _smtpService.SendMailAsync(mailDTO);
        }
    }
}
