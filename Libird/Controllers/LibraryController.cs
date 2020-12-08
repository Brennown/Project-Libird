using System.Threading.Tasks;
using Libird.Interface;
using Libird.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Libird.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IBook _bookService;
        private readonly IAccount _accountervice;

        public LibraryController(IBook bookService, IAccount accountService)
        {
            _bookService = bookService;
            _accountervice = accountService;
        }
        public async Task<IActionResult> Index()
        {
            var userName = User.Identity.Name;
            var accountId = await _accountervice.SearchAccountIdByUserName(userName);
            var listBook = await _bookService.GetAllBookByAccountId(accountId);

            var viewModel = new Library 
            { 
                Books = listBook
            };

            return View(viewModel);
        }
    }
}
