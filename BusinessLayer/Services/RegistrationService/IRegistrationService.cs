using System;
using System.Threading.Tasks;
using BusinessLayer.DTOs;

namespace BusinessLayer.Services.RegistrationService
{
    public interface IRegistrationService
    {
        Task<Guid> RegisterUserAsync(AccountInfoDTO accountInfoDTO, string uri);
        Task<bool> ConfirmEmailAsync(string email, string message);
    }
}
