using Libird.Data.Context;
using Libird.Data.Generic;
using Libird.Interface;
using Libird.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Libird.Data.Services
{
    public class BookService : GenericContext , IBook
    {
        public BookService(ApplicationContext context) : base(context)
        {
        }

        public void AddNewBook(int accountId, Book book, Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();

            var resultAuthor = _context.Authors.FirstOrDefault(x => x.Name == author.Name && x.LastName == author.LastName);
            var authorId = resultAuthor.AuthorId;

            book.AuthorId = authorId;
            _context.Books.Add(book);
            _context.SaveChanges();

            var resultBook = _context.Books.FirstOrDefault(x => x.Isbn == book.Isbn);
            var bookId = resultBook.BookId;


            var bookAccount = new BookAccount { AccountId = accountId, BookId = bookId };
            _context.BookAccounts.Add(bookAccount);
            _context.SaveChanges();
        }

        public async Task<List<Book>> GetAllBookByAccountId(int accountId)
        {
            var result = from obj in _context.Books select obj;

            return await result
                .Include(x => x.Author)
                .Include(x => x.BookAccounts)
                .Where(x => x.BookAccounts.Any(x => x.AccountId == accountId))
                .ToListAsync();
        }
    }
}
