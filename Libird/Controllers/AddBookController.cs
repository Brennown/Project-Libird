using Libird.Interface;
using Libird.Models.Domain;
using Libird.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Libird.Controllers
{
    public class AddBookController : Controller
    {
        private readonly IAccount _accountService;
        private readonly IBook _bookService;
        public AddBookController(IAccount accountService, IBook bookService)
        {
            _accountService = accountService;
            _bookService = bookService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            var account = await _accountService.SearchAccountById(id.Value);
            var viewModel = new AddNewBook { Account = account, AccountId = account.AccountId};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void AddNewBook(int accountId, Book book , Author author)
        {
            _bookService.AddNewBook(accountId, book, author);
        }
    }
}
