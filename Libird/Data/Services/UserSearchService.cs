using Libird.Data.Context;
using Libird.Data.Generic;
using Libird.Interface;
using Libird.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libird.Data.Services
{
    public class UserSearchService : GenericContext , IUserSearch
    {
        public UserSearchService(ApplicationContext context) : base(context)
        {
        }

        public async Task<User> UserSearch(Account account)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Account.UserName == account.UserName);
            return user;
        }
    }
}
