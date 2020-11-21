using Libird.Models.Domain;

namespace Libird.Interface
{
    public interface IBook
    {
        void AddNewBook(int accountId, Book book, Author author);
    }
}
