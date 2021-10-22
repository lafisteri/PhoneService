using System.Threading.Tasks;
using BusinessLayer.Services.HashService;
using Core.Enums;
using Core.Models;
using DataLayer.UserRepository;

namespace BusinessLayer.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashService _hashService;

        public UserService(
            IUserRepository userRepository,
            IHashService hashService)
        {
            _userRepository = userRepository;
            _hashService = hashService;
        }

        public async Task<Role?> GetRoleByLoginInfoAsync(LoginInfo loginInfo)
        {
            loginInfo.Password = _hashService.HashString(loginInfo.Password);

            return await _userRepository.GetRoleByLoginInfoAsync(loginInfo);
        }

        public async Task UpdatePasswordAsync(LoginInfo loginInfo)
        {
            loginInfo.Password = _hashService.HashString(loginInfo.Password);

            await _userRepository.UpdatePasswordAsync(loginInfo);
        }

        public async Task<bool> VerifyPasswordAsync(LoginInfo loginInfo)
        {
            loginInfo.Password = _hashService.HashString(loginInfo.Password);

            return await _userRepository.VerifyLoginInfoAsync(loginInfo);
        }
    }
}
