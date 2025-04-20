using Library.DTOs;
using Library.Model;
using Microsoft.AspNetCore.Mvc;

namespace Library.IServices
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(Guid id);
        Task<Author> CreateAuthor(CreateAuthorDto entity);
        Task<Author> UpdateAuthor(Author entity);
        Task<bool> DeleteAuthor(Guid id);
    }
}
