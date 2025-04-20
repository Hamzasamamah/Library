using Library.DTOs;
using Library.IRepository;
using Library.IServices;
using Library.Model;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IBookAuthorRepository _bookAuthorRepository;

        public BookService(IBookRepository repository, IBookAuthorRepository bookAuthorRepository)
        {
            _repository = repository;
            _bookAuthorRepository = bookAuthorRepository;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Book> GetBookById(Guid id)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }
            return book;
        }

        public async Task<CreateBookDto> CreateBook(CreateBookDto dto)
        {
            var entity = new Book
            {
                Title = dto.Title,
                Published = dto.Published,
            };

            var book = await _repository.AddAsync(entity);

            var bookAuthor = new BookAuthor
            {
                BookId = book.Id,
                AuthorId = dto.AuthorId,
            };

            await _bookAuthorRepository.AddAsync(bookAuthor);

            return new CreateBookDto
            {
                Title = book.Title,
                Published = book.Published,
                AuthorId = dto.AuthorId
            };
        }

        public async Task<CreateBookDto> UpdateBook(Guid id, CreateBookDto entity)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }

            book.Title = entity.Title;
            book.Published = entity.Published;
            book.Updated = DateTime.UtcNow;

            var bookAuthor = await _bookAuthorRepository.GetByBookIdAsync(id);

            if (bookAuthor != null)
            {
                bookAuthor.AuthorId = entity.AuthorId;
                await _bookAuthorRepository.UpdateAsync(bookAuthor);
            }

            var updatedBook = await _repository.UpdateAsync(book);
            await _bookAuthorRepository.UpdateAsync(bookAuthor);

            return new CreateBookDto
            {
               Title= updatedBook.Title,
               Published = updatedBook.Published,
               AuthorId = bookAuthor.AuthorId
            };
        }

        public async Task<bool> DeleteBook(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

    }
}
