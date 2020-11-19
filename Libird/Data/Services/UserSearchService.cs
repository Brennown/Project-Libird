using Libird.Data.Context;
using Libird.Data.Generic;
using Libird.Interface;
using Libird.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Libird.Data.Services
{
    public class UserSearchService : GenericContext , IUser
    {
        public UserSearchService(ApplicationContext context) : base(context)
        {
        }

        public async Task<User> SearchUserByAccount(Account account)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Account.UserName == account.UserName);
            return user;
        }
    }
}
