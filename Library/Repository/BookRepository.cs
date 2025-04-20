using Library.Data;
using Library.IRepository;
using Library.Model;

namespace Library.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }
    }
}
