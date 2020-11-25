using Libird.Models.Domain;
using System.Threading.Tasks;

namespace Libird.Interface
{
    public interface IAuthor
    {
        Task AddAuthor(Author author);
        Task<int> GetAuthorIdByName(Author author);
    }
}
