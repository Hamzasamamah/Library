using Library.DTOs;
using Library.Model;

namespace Library.IServices
{
    public interface IBookAuthorService
    {
        Task<BookAuthor> CreateBookAuthor(CreateBookAuthorDto entity);
        Task<BookAuthor> UpdateBookAuthor(BookAuthor entity);
        Task<bool> DeleteBookAuthor(Guid id);
    }
}
