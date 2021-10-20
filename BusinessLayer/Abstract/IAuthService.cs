using Core.Models;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        string Login(LoginInfo loginInfo);
    }
}
