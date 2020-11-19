using Libird.Data.Context;
using Libird.Data.Generic;
using Libird.Interface;
using Libird.Models.Domain;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Libird.Data.Services
{
    public class AccountService : GenericContext, IAccount
    {
        public AccountService(ApplicationContext context) : base(context)
        {

        }

        public async Task<Account> SearchAccountById(int accountId)
        {
            return await _context.Accounts.Include(x => x.User).FirstOrDefaultAsync(x => x.AccountId == accountId);
        }

        public async Task<Account> SearchAccountByUserName(string userName)
        {
            return await _context.Accounts.Include(x => x.User).FirstOrDefaultAsync(x => x.UserName == userName);
        }
    }
}
