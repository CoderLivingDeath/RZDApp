using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using rzd;
using RZDModel.Interfaces.Services;
using System.Security.Claims;

namespace WebRZD.Controllers.ViewControllers
{
    [Route("Authorization")]
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationService AuthorizationService;
        private readonly IUserService UserService;

        private readonly ILogger<AuthorizationController> Logger;

        public AuthorizationController(IAuthorizationService authorizationService, IUserService userService, ILogger<AuthorizationController> logger)
        {
            AuthorizationService = authorizationService;
            UserService = userService;
            Logger = logger;
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("Registration")]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] string Login, [FromForm] string Password)
        {
            if (AuthorizationService.Authenticate(Login, Password, out var id))
            {
                var user = UserService.GetById(id);

                List<Claim> claims = new List<Claim>() { new Claim("Login", Login), new Claim("Password", Password), new Claim("role", user.Role), new Claim("UserId", user.id.ToString()) };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                await HttpContext.AuthenticateAsync();

                Logger.Log(LogLevel.Information, "авторизован");
                return Redirect(Url.Action(controller: "Index", action: "Index"));
            }

            return View();
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromForm] string FullName, [FromForm] string Login, [FromForm] string Password)
        {
            if (!AuthorizationService.TryGetUserCredentials(Login, out _))
            {
                var user = UserService.CreateNewUser(FullName, "user");
                AuthorizationService.CreateCredentials(Login, Password, user.id);

                List<Claim> claims = new List<Claim>() { new Claim("Login", Login), new Claim("Password", Password), new Claim("role", user.Role), new Claim("UserId", user.id.ToString()) };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                await HttpContext.AuthenticateAsync();

                return Redirect(Url.Action(controller: "Index", action: "Index"));
            }

            return View();
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect(Url.Action(controller: "Index", action: "Index"));
        }
    }
}
