using System.Threading.Tasks;
using Libird.Interface;
using Libird.Models.Domain;
using Libird.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Libird.Controllers
{
    [Authorize]
    public class LibraryController : Controller
    {
        private readonly IBook _bookService;
        private readonly IAccount _accountService;

        public LibraryController(IBook bookService, IAccount accountService)
        {
            _bookService = bookService;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userName = User.Identity.Name;
            var accountId = await _accountService.SearchAccountIdByUserName(userName);
            var listBook = await _bookService.GetAllBookByAccountId(accountId);

            var viewModel = new Library 
            { 
                Books = listBook
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            var userName = User.Identity.Name;
            var accountId = await _accountService.SearchAccountIdByUserName(userName);
            var viewModel = new AddNewBook { AccountId = accountId };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(int accountId, Book book, Author author)
        {
            await _bookService.InsertBook(accountId, book, author);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            var Book = await _bookService.GetBookById(id.Value);
            return View(Book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Book book)
        {
            await _bookService.UpdateBook(book);
            return RedirectToAction(nameof(Index));
        } 

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var Book = await _bookService.GetBookById(id.Value);
            return View(Book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int bookid)
        {
            var accountId = await _accountService.SearchAccountIdByUserName(User.Identity.Name);
            await _bookService.DeleteBook(accountId, bookid);
            return RedirectToAction(nameof(Index));
        }
    }
}
