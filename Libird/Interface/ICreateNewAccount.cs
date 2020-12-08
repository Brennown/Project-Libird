using Libird.Models.Domain;
using System.Threading.Tasks;

namespace Libird.Interface
{
    public interface ICreateNewAccount
    {
        Task CreateNewAccountAsync(User user, Account account);
    }
}
