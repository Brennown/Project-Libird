using Libird.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libird.Models.ViewModels
{
    public class Library
    {
        public Book Book { get; set; }
        public ICollection<Book> Books { get; set; }
        public Account Account { get; set; }
        public int AccountId { get; set; }
    }
}
