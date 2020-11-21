using Libird.Models.Domain;

namespace Libird.Models.ViewModels
{
    public class AddNewBook
    {
        public Book Book { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public Author Author { get; set; }
    }
}
