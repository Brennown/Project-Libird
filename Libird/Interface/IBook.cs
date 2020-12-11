using Libird.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Libird.Interface
{
    public interface IBook
    {
        Task<List<Book>> GetAllBookByAccountId(int accountId);
        Task<Book> GetBookById(int bookId);
        Task<int> GetBookIdByIsbn(string isbn);
        Task InsertBook(int accountId, Book book, Author author);
        Task DeleteBook(int accountId, int Bookid);
        Task UpdateBook(Book book);
    }
}
