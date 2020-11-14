using Libird.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libird.Interface
{
    public interface IUserSearch
    {
        Task<User> UserSearch(Account account); 
    }
}
