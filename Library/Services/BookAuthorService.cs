using Library.DTOs;
using Library.IRepository;
using Library.IServices;
using Library.Model;

namespace Library.Services
{
    public class BookAuthorService : IBookAuthorService
    {
        
        private readonly IBookAuthorRepository _repository;

        public BookAuthorService(IBookAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookAuthor> CreateBookAuthor(CreateBookAuthorDto dto)
        {
            var entity = new BookAuthor
            {
                BookId = dto.BookId,
                AuthorId = dto.AuthorId,
                Created = DateTime.UtcNow
            };

            return await _repository.AddAsync(entity);
        }

        public async Task<BookAuthor> UpdateBookAuthor(BookAuthor entity)
        {
            var bookAuthor = await _repository.GetByIdAsync(entity.Id);
            if (bookAuthor == null)
            {
                throw new KeyNotFoundException($"Book author wuth ID {entity.Id} not found.");
            }

            bookAuthor.BookId = entity.BookId;
            bookAuthor.AuthorId = entity.AuthorId;
            bookAuthor.Updated = DateTime.UtcNow;

            return await _repository.UpdateAsync(bookAuthor);
        }

        public async Task<bool> DeleteBookAuthor(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
