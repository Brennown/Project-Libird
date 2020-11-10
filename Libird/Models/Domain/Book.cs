using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libird.Models.Domain
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string NumberPage { get; set; }
        public string NumberEdition { get; set; }
        public string Isbn { get; set; }
        public string Genre { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<BookAccount> BookAccounts { get; set; }
    }
}
