using Libird.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Libird.Interface
{
    public interface IBook
    {
        Task<List<Book>> GetAllBookByAccountId(int accountId);
        Task<Book> GetBookById(int bookId);
        Task AddNewBook(int accountId, Book book, Author author);

        Task<int> GetBookIdByIsbn(string isbn);
        Task AddBook(int authorId, Book book);
        Task DeleteBook(int accountId, int Bookid);
    }
}
