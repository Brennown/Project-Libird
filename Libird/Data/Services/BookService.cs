using Libird.Data.Context;
using Libird.Data.Generic;
using Libird.Interface;
using Libird.Models.Domain;
using System.Linq;

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
    }
}
