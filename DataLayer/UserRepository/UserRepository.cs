using System;
using System.Threading.Tasks;
using Core.Enums;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextMsSql _dbContext;

        public UserRepository(ContextMsSql dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddUserAsync(AccountInfo accountInfo)
        {
            accountInfo.Id = Guid.NewGuid();
            _dbContext.Users.Add(accountInfo);

            var result = await _dbContext.SaveChangesAsync();

            return result != 0 ? accountInfo.Id : Guid.Empty;
        }

        public async Task<Role?> GetRoleByLoginInfoAsync(LoginInfo loginInfo)
        {
            var account = await GetAccountInfoByLoginInfoAsync(loginInfo);

            return account?.Role;
        }

        public async Task UpdatePasswordAsync(LoginInfo loginInfo)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.LoginInfo.Login == loginInfo.Login);
            user.LoginInfo.Password = loginInfo.Password;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> VerifyLoginInfoAsync(LoginInfo loginInfo)
        {
            var account = await GetAccountInfoByLoginInfoAsync(loginInfo);

            return account != null;
        }

        private async Task<AccountInfo> GetAccountInfoByLoginInfoAsync(LoginInfo loginInfo)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(accountInfo =>
                            accountInfo.LoginInfo.Login == loginInfo.Login &&
                            accountInfo.LoginInfo.Password == loginInfo.Password);
        }
    }
}
