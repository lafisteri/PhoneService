using System.Threading.Tasks;
using BusinessLayer.DTOs;
using BusinessLayer.Services.AuthService;
using BusinessLayer.Services.RegistrationService;
using BusinessLayer.Services.UserService;
using Core.Enums;
using Core.Models;
using Core.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace PresentationLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly ILogger<AccountsController> _logger;
        private readonly IRegistrationService _registrationService;


        public AccountsController(IAuthService authService,
            IUserService userService,
            ILogger<AccountsController> logger,
            IRegistrationService registrationService)
        {
            _authService = authService;
            _userService = userService;
            _logger = logger;
            _registrationService = registrationService;
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
                _logger.LogInformation($"User logged in {loginInfo.Login} !");

                return Ok(token);
            }

            _logger.LogWarning($"User login failed: {loginInfo}");
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

        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountInfoDTO accountInfo)
        {
            return Ok(await _registrationService.RegisterUserAsync(accountInfo));
        }
    }
}
