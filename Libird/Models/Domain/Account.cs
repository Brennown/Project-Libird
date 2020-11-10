using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libird.Models.Domain
{
    public class Account
    {
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<BookAccount> BookAccounts { get; set; }
    }
}
