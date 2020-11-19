using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Libird.Models.Domain;
using Libird.Interface;

namespace Libird.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccount _accountService; 
        private Account _userAccount;

        public HomeController(IAccount accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> Index(Account account, int? id)
        {
           
            if (account.UserName != null)
            {
                _userAccount = await _accountService.SearchAccountByUserName(account.UserName);
            }
            else
            {
                _userAccount = await _accountService.SearchAccountById(id.Value);
            }
          
            return View(_userAccount);
        }
    }
}
