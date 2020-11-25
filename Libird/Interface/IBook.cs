using Libird.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Libird.Interface
{
    public interface IBook
    {
        Task<List<Book>> GetAllBookByAccountId(int accountId);
        Task AddNewBook(int accountId, Book book, Author author);
    }
}
