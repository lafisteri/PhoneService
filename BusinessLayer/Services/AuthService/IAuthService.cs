using Core.Models;

namespace BusinessLayer.Services.AuthService
{
    public interface IAuthService
    {
        string CreateAuthToken(UserInfo userInfo);

        UserInfo GetUserInfoFromToken(string headerToken);
    }
}
