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
        private readonly ICreateNewAccount _createNewAccount;

        public InputController(ICreateNewAccount createNewAccount)
        {
            _createNewAccount = createNewAccount;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SingUp(User user , Account account)
        {
            var result = await _createNewAccount.CreateNewAccountAsync(user, account);
            return Json(result);
        }
    }
}
