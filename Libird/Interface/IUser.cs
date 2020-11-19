using Libird.Models.Domain;
using System.Threading.Tasks;

namespace Libird.Interface
{
    public interface IUser
    {
        Task<User> SearchUserByAccount(Account account); 
    }
}
