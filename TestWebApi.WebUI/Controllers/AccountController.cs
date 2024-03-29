using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestWebApi.Application.Services.Abstarction;
using TestWebApi.Domain.Models;
using TestWebApi.WebUI.Contracts;

namespace TestWebApi.WebUI.Controllers
{
    [Controller]
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRequest request)
        {
            var user = new User()
            {
                Login = request.login
            };

            await _userService.Register(user, request.password);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserRequest request)
        {
            var user = await _userService.Login(request.login, request.password);

            var claims = new List<Claim>
            {
                new Claim("login",user.Login),
                new Claim("id", user.Id.ToString())
            };

            ClaimsIdentity identity  = new ClaimsIdentity(claims,"Cookies");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return Ok(user);
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
        
    }
}
