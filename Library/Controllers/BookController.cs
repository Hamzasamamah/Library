using Library.DTOs;
using Library.IServices;
using Library.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookService _Service;
        public BookController(IBookService service)
        {
            _Service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _Service.GetAllBooks();
            if (books == null)
            {
                return NotFound("no books found");
            }
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var books = await _Service.GetBookById(id);
            if (books == null)
            {
                return NotFound($"Book with ID {id} not found.");
            }
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookDto book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdBook = await _Service.CreateBook(book);

            if (createdBook == null)
                return StatusCode(500, "Failed to create book.");

            return Ok(createdBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateBook(Guid id, CreateBookDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
               

                var updatedBook= await _Service.UpdateBook(id , dto);

                return Ok(updatedBook);
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
        public async Task<IActionResult> deleteBook(Guid id)
        {
            var result = await _Service.DeleteBook(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound("Book not exist.");
        }
    }
}
