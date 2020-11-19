using System.Collections.Generic;

namespace Libird.Models.Domain
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
