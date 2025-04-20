using Library.DTOs;
using Library.Model;

namespace Library.IRepository
{
    public interface IBookAuthorRepository : IGenericRepository<BookAuthor>
    {
        Task<BookAuthor> GetByBookIdAsync(Guid bookId);

    }
}
