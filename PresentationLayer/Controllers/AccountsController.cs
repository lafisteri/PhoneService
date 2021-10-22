using System.Threading.Tasks;
using BusinessLayer.Services.AuthService;
using BusinessLayer.Services.UserService;
using Core.Enums;
using Core.Models;
using Core.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AccountsController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginInfo loginInfo)
        {
            var userRole = await _userService.GetRoleByLoginInfoAsync(loginInfo);
            if (userRole != null)
            {
                var token = _authService.CreateAuthToken(new UserInfo
                {
                    Login = loginInfo.Login,
                    Role = userRole.Value
                });

                return Ok(token);
            }

            return BadRequest("Invalid username or password.");
        }

        [Authorize(Roles = nameof(Role.Admin))]
        [HttpPut("password")]
        public async Task<IActionResult> UpdatePassword(PasswordChangeRequest request)
        {
            var authHeader = Request.Headers["Authorization"][0];

            var userInfo = _authService.GetUserInfoFromToken(authHeader);

            var loginInfo = new LoginInfo
            {
                Login = userInfo.Login,
                Password = request.OldPassword
            };

            var passwordCorrect = await _userService.VerifyPasswordAsync(loginInfo);
            if (passwordCorrect)
            {
                loginInfo.Password = request.NewPassword;
                await _userService.UpdatePasswordAsync(loginInfo);

                return Ok("Password updated!");
            }

            return BadRequest("Invalid login or password!");
        }
    }
}
