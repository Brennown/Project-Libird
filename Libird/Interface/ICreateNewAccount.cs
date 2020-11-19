using Libird.Models.Domain;
using System.Threading.Tasks;

namespace Libird.Interface
{
    public interface ICreateNewAccount
    {
        Task<string> CreateNewAccountAsync(User user, Account account);
    }
}
