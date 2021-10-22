using System.Threading.Tasks;
using Core.Enums;
using Core.Models;

namespace BusinessLayer.Services.UserService
{
    public interface IUserService
    {
        Task UpdatePasswordAsync(LoginInfo loginInfo);
        Task<bool> VerifyPasswordAsync(LoginInfo loginInfo);
        Task<Role?> GetRoleByLoginInfoAsync(LoginInfo loginInfo);
    }
}
