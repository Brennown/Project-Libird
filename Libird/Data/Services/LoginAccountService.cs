using Libird.Data.Context;
using Libird.Data.Generic;
using Libird.Interface;
using Libird.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Libird.Data.Services
{
    public class LoginAccountService : GenericContext, ILoginAccount
    {
        public LoginAccountService(ApplicationContext context) : base(context)
        {
        }

       
        public async Task<bool> LoginAccountAsync(Account account)
        {
            var hasAny = await _context.Accounts.AnyAsync(x => x.UserName == account.UserName && x.Password == account.Password);
            if (!hasAny)
            {
                return false;
            }

            return true;
        }
    }
}
