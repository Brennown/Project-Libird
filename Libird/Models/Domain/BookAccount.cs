using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Libird.Models.Domain
{
    public class BookAccount
    {
        public int BookAccountId { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
