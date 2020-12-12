using Libird.Models.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Libird.Models.Domain
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        [Display(Name ="Subtitle")]
        public string SubTitle { get; set; }
        [Display(Name ="Page")]
        public string NumberPage { get; set; }
        [Display(Name ="Edition")]
        public string NumberEdition { get; set; }
        [Display(Name ="ISBN")]
        public string Isbn { get; set; }
        public string Genre { get; set; }
        public Type Type { get; set; }
        public bool Read { get; set; }
        public bool Borrowed { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<BookAccount> BookAccounts { get; set; }
    }
}
