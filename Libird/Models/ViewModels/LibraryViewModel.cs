using Libird.Models.Domain;
using System.Collections.Generic;

namespace Libird.Models.ViewModels
{
    public class LibraryViewModel
    {
        public Book Book { get; set; }
        public List<Book> Books { get; set; }
        public int Code { get; set; }
        public int CountBook { get; set; }
    }
}
