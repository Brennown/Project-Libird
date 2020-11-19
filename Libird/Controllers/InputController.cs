using Libird.Interface;
using Libird.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Libird.Controllers
{
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
        public IActionResult SingUp()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SingIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SingUp(User user , Account account)
        {
            await _createNewAccountService.CreateNewAccountAsync(user, account);
            return RedirectToAction("Index", "Home", new { UserName = account.UserName });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SingIn(Account account)
        {
            var hasAny = await _loginAccountService.LoginAccountAsync(account);
            if (!hasAny)
            {
                return BadRequest("User Name or Password not exist!!");
            }
            return RedirectToAction("Index", "Home", new { UserName = account.UserName });
        }
    }
}
