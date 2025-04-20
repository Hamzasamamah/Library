using Library.DTOs;
using Library.IServices;
using Library.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookAuthorController : ControllerBase
    {
        private readonly IBookAuthorService _Service;
        public BookAuthorController(IBookAuthorService service)
        {
            _Service = service;
        }

        

        [HttpPost]
        public async Task<IActionResult> CreateBookAuthor(CreateBookAuthorDto bookAuthor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdBookAuthor = await _Service.CreateBookAuthor(bookAuthor);

            if (createdBookAuthor == null)
                return StatusCode(500, "Failed to create bookAuthor.");

            return Ok(createdBookAuthor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateBookAuthor(Guid id, CreateBookAuthorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var bookAuthor = new BookAuthor
                {
                    BookId = dto.BookId,
                    AuthorId = dto.AuthorId,
                    Created = DateTime.UtcNow
                };
                bookAuthor.Id = id;

                var updatedBookAuthor = await _Service.UpdateBookAuthor(bookAuthor);

                return Ok(updatedBookAuthor);
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
        public async Task<IActionResult> deleteBookAuthor(Guid id)
        {
            var result = await _Service.DeleteBookAuthor(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound("BookAuthor not exist.");
        }
    }
}
