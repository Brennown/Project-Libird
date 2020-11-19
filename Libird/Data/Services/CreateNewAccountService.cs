﻿using Libird.Data.Context;
using Libird.Data.Generic;
using Libird.Interface;
using Libird.Models.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Libird.Data.Services
{
    public class CreateNewAccountService : GenericContext , ICreateNewAccount
    {
        public CreateNewAccountService(ApplicationContext context) : base(context)
        {
        }


        public async Task<string> CreateNewAccountAsync(User user, Account account)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var userId = _context.Users.First(x => x.Name == user.Name);

            account.UserId = userId.UserId;

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return "Account Created with success";
        }
    }
}
