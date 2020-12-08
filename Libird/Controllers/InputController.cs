using Libird.Interface;
using Libird.Models.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Libird.Controllers
{
    [AllowAnonymous]
    public class InputController : Controller
    {
        private readonly ICreateNewAccount _createNewAccountService;
        private readonly ILoginAccount _loginAccountService;

        public InputController(ICreateNewAccount createNewAccountService, ILoginAccount loginAccountService)
        {
            _createNewAccountService = createNewAccountService;
            _loginAccountService = loginAccountService;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignIn(string message)
        {
            ViewBag.MessageError = message;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(User user , Account account)
        {
            await _createNewAccountService.CreateNewAccountAsync(user, account);
            await Authentication(account);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(Account account)
        {
            var hasAny = await _loginAccountService.LoginAccountAsync(account);
            if (!hasAny)
            {
                return RedirectToAction(nameof(SignIn), new { message = "Username or password is incorret!!" });
            }
            await Authentication(account);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }

        private async Task Authentication(Account account)
        {
            ClaimsIdentity identity = new ClaimsIdentity("CookieAuth");
            identity.AddClaim(new Claim(ClaimTypes.Name, $"{account.UserName}"));
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(claimsPrincipal);
        }
    }
}
