using Library.Data;
using Library.IRepository;
using Library.Model;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
    public class BookAuthorRepository : GenericRepository<BookAuthor>, IBookAuthorRepository
    {
        private readonly AppDbContext _context;
        public BookAuthorRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BookAuthor> GetByBookIdAsync(Guid bookId)
        {
            return await _context.BookAuthor.FirstOrDefaultAsync(ba => ba.BookId == bookId);
        }
    }
}
