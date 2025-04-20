
namespace Library.Model
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public string Bio { get; set; }
     

        //BookAuthor
        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

    }
}
