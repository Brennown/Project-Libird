using Libird.Models.Domain;
using System.Threading.Tasks;

namespace Libird.Interface
{
    public interface IAccount
    {
        Task<Account> SearchAccountByUserName(string userName);
        Task<Account> SearchAccountById(int accountId);
    }
}
