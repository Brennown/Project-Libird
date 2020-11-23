using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> Index(int? id)
        {
            var account = await _accountervice.SearchAccountById(id.Value);
            var listBook = await _bookService.GetAllBookByAccountId(id.Value);

            var viewModel = new Library 
            { 
                Account = account, 
                Books = listBook
            };

            return View(viewModel);
        }
    }
}
