using Libird.Interface;
using Libird.Models.Domain;
using Libird.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Libird.Controllers
{
    [Authorize]
    public class AddBookController : Controller
    {
        private readonly IAccount _accountService;
        private readonly IBook _bookService;
        public AddBookController(IAccount accountService, IBook bookService)
        {
            _accountService = accountService;
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var userName = User.Identity.Name;
            var accountId = await _accountService.SearchAccountIdByUserName(userName);
            var viewModel = new AddNewBook {AccountId = accountId};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewBook(int accountId, Book book , Author author)
        {
            await _bookService.AddNewBook(accountId, book, author);
            return RedirectToAction("Index", "Library");
        }
    }
}
