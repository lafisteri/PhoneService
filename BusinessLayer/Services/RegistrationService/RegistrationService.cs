using System;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.DTOs;
using BusinessLayer.Services.HashService;
using Core.Models;
using DataLayer.EmailRepository;
using DataLayer.UserRepository;

namespace BusinessLayer.Services.RegistrationService
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHashService _hashService;
        private readonly IEmailRepository _emailRepository;

        public RegistrationService(IUserRepository userRepository,
            IMapper mapper,
            IHashService hashService,
            IEmailRepository emailRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _hashService = hashService;
            _emailRepository = emailRepository;
        }

        public async Task<Guid> RegisterUserAsync(AccountInfoDTO accountInfoDTO)
        {
            var accountInfo = _mapper.Map<AccountInfo>(accountInfoDTO);
            accountInfo.LoginInfo.Password = _hashService.HashString(accountInfo.LoginInfo.Password); ;

            int? emailId = await SaveEmailIntoDB(accountInfoDTO);
            accountInfo.EmailId = emailId.Value;

            return await _userRepository.AddUserAsync(accountInfo);
        }

        private async Task<int?> SaveEmailIntoDB(AccountInfoDTO accountInfoDTO)
        {
            int? emailId = null;
            if (!string.IsNullOrEmpty(accountInfoDTO.Email))
            {
                var mail = new Email
                {
                    PostName = accountInfoDTO.Email,
                    IsConfirmed = false,
                    ConfirmationString = "confirm_string"
                };

                emailId = await _emailRepository.RegisterEmailAsync(mail);
            }

            return emailId;
        }
    }
}
