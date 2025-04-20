using Library.DTOs;
using Library.Model;

namespace Library.IServices
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(Guid id);
        Task<CreateBookDto> CreateBook(CreateBookDto entity);
        Task<CreateBookDto> UpdateBook(Guid id , CreateBookDto entity);
        Task<bool> DeleteBook(Guid id);
    }
}
