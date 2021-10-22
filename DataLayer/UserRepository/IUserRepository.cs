using System.Threading.Tasks;
using Core.Enums;
using Core.Models;

namespace DataLayer.UserRepository
{
    public interface IUserRepository
    {
        Task<Role?> GetRoleByLoginInfoAsync(LoginInfo loginInfo);
        Task UpdatePasswordAsync(LoginInfo loginInfo);
        Task<bool> VerifyLoginInfoAsync(LoginInfo loginInfo);
    }
}
