using Library.DTOs;
using Library.IServices;
using Library.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _Service;
        public AuthorController(IAuthorService service)
        {
            _Service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _Service.GetAllAuthors();
            if (authors == null)
            {
                return NotFound("no authors found");
            }
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var author = await _Service.GetAuthorById(id);
            if (author == null)
            {
                return NotFound($"Author with ID {id} not found.");
            }
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDto author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdAuthor = await _Service.CreateAuthor(author);

            if (createdAuthor == null)
                return StatusCode(500, "Failed to create author.");

            return Ok(createdAuthor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateAuthor(Guid id, CreateAuthorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var author = new Author
                {
                    Id = id,
                    Name = dto.Name,
                    Bio  = dto.Bio
                };

                var updatedAuthor = await _Service.UpdateAuthor(author);

                return Ok(updatedAuthor);
            }
            catch (KeyNotFoundException e)
            {

                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteAuthor(Guid id)
        {
            var result = await _Service.DeleteAuthor(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound("Author not exist.");
        }
    }
}
