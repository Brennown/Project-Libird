using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libird.Interface
{
    public interface IBookAccount
    {
        Task AddBookAccount(int accountId, int bookId);
    }
}
