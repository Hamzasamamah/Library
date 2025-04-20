
namespace Library.Model
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public DateTime Published { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
