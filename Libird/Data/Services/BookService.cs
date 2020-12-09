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
    public class BookService : GenericContext, IBook, IAuthor, IBookAccount
    {
        public BookService(ApplicationContext context) : base(context)
        {
        }

        public async Task AddBook(int authorId, Book book)
        {
            book.AuthorId = authorId;
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }
        public async Task AddBookAccount(int accountId, int bookId)
        {
            var bookAccount = new BookAccount { AccountId = accountId, BookId = bookId };
            _context.BookAccounts.Add(bookAccount);
            await _context.SaveChangesAsync();
        }
        public async Task AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }
        public async Task<int> GetAuthorIdByName(Author author)
        {
            var result = await _context.Authors.FirstOrDefaultAsync(x => x.Name == author.Name && x.LastName == author.LastName);
            var authorId = result.AuthorId;
            return authorId;
        }
        public async Task<int> GetBookIdByIsbn(string isbn)
        {
            var Book = await _context.Books.FirstOrDefaultAsync(x => x.Isbn == isbn);
            var bookId = Book.BookId;
            return bookId;
        }

        public async Task AddNewBook(int accountId, Book book, Author author)
        {
            var anyAuthor = await hasAnyAuthor(author);

            if (anyAuthor)
            {
                author.AuthorId = await GetAuthorIdByName(author);
            }
            else
            {
                await AddAuthor(author);
                author.AuthorId = await GetAuthorIdByName(author);
            }
            
            var anyBook = await hasAnyBook(book.Isbn);

            if (anyBook)
            {
                book.BookId = await GetBookIdByIsbn(book.Isbn);
            }
            else
            {
                await AddBook(author.AuthorId, book);
                book.BookId = await GetBookIdByIsbn(book.Isbn);
            }
           
            await AddBookAccount(accountId, book.BookId);
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

        public async Task DeleteBook(int accountId, int Bookid)
        {
            var bookAccount = await _context.BookAccounts.FirstOrDefaultAsync(x => x.AccountId == accountId && x.BookId == Bookid);
            _context.Remove(bookAccount);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetBookById(int bookId)
        {
            return await _context.Books.Include(x => x.Author).FirstOrDefaultAsync(x => x.BookId == bookId);
        }

        private async Task<bool> hasAnyBook(string isbn)
        {
            return await _context.Books.AnyAsync(x => x.Isbn == isbn);
        }
        private async Task<bool> hasAnyAuthor(Author author)
        {
            return await _context.Authors.AnyAsync(x => x.Name == author.Name && x.LastName == author.LastName);
        }
    }
}
