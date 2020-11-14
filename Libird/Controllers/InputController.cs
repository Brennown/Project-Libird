using Libird.Data.Services;
using Libird.Interface;
using Libird.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libird.Controllers
{
    public class InputController : Controller
    {
        private readonly ICreateNewAccount _createNewAccountService;
        private readonly ILoginAccount _loginAccountService;
        private readonly IUserSearch _userSearchService;

        public InputController(ICreateNewAccount createNewAccountService, ILoginAccount loginAccountService, IUserSearch userSeachService)
        {
            _createNewAccountService = createNewAccountService;
            _loginAccountService = loginAccountService;
            _userSearchService = userSeachService;
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
            var result = await _createNewAccountService.CreateNewAccountAsync(user, account);
            return RedirectToAction("Index", "Home", new { Name = user.Name, LastName = user.LastName});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SingIn(Account account)
        {
            var hasAny = await _loginAccountService.LoginAccountAsync(account);
            var name = await _userSearchService.UserSearch(account);
            if (!hasAny)
            {
                return BadRequest("User Name or Password not exist!!");
            }
            return RedirectToAction("Index","Home", new { Name = name.Name, LastName = name.LastName});
        }
    }
}
