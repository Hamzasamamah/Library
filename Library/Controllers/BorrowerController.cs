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
    public class BorrowerController : ControllerBase
    {
        private readonly IBorrowerService _Service;
        public BorrowerController(IBorrowerService service)
        {
            _Service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBorrower()
        {
            var borrowers = await _Service.GetAllBorrowers();
            if (borrowers == null)
            {
                return NotFound("no borrowers found");
            }
            return Ok(borrowers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var borrower = await _Service.GetBorrowerById(id);
            if (borrower == null)
            {
                return NotFound($"Borrower with ID {id} not found.");
            }
            return Ok(borrower);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBorrower(CreateBorrowerDto borrower)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdBorrower = await _Service.CreateBorrower(borrower);

            if (createdBorrower == null)
                return StatusCode(500, "Failed to create borrower.");

            return Ok(createdBorrower);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateBorrower(Guid id, CreateBorrowerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var borrower = new Borrower
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    Phone = dto.Phone
                };

                borrower.Id = id;

                var updatedBorrower = await _Service.UpdateBorrower(borrower);

                return Ok(updatedBorrower);
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
        public async Task<IActionResult> deleteBorrower(Guid id)
        {
            var result = await _Service.DeleteBorrower(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound("Borrower not exist.");
        }
    }
}
