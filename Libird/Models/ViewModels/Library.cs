using Libird.Models.Domain;
using System.Collections.Generic;

namespace Libird.Models.ViewModels
{
    public class Library
    {
        public Book Book { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
