using Library.DTOs;
using Library.IRepository;
using Library.IServices;
using Library.Model;
using Library.Repository;

namespace Library.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Author> GetAuthorById(Guid id)
        {
            var author = await _repository.GetByIdAsync(id);
            if (author == null)
            {
                throw new KeyNotFoundException($"Author with ID {id} not found");
            }
            return author;
        }

        public async Task<Author> CreateAuthor(CreateAuthorDto dto)
        {
            var entity = new Author
            {
                Name = dto.Name,
                Bio = dto.Bio
            };
            return await _repository.AddAsync(entity);
        }

        public async Task<Author> UpdateAuthor(Author entity)
        {
            var author = await _repository.GetByIdAsync(entity.Id);
            if (author == null)
            {
                throw new KeyNotFoundException($"Author with ID {entity.Id} not found");
            }

            author.Name = entity.Name;
            author.Bio = entity.Bio;
            author.Updated = DateTime.UtcNow;

            return await _repository.UpdateAsync(author);
        }

        public async Task<bool> DeleteAuthor(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

     
    }
}
