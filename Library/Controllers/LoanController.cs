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
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _Service;
        public LoanController(ILoanService service)
        {
            _Service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLoans()
        {
            var loans = await _Service.GetAllLoans();
            if (loans == null)
            {
                return NotFound("no loans found");
            }
            return Ok(loans);
        }

        

        [HttpPost]
        public async Task<IActionResult> CreateLoan(CreateLoanDto loan)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdLoan = await _Service.CreateLoan(loan);

            if (createdLoan == null)
                return StatusCode(500, "Failed to create loan.");

            return Ok(createdLoan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateLoan(Guid id, CreateLoanDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var loan = new Loan 
                {
                    Id = id,
                    BookId = dto.BookId,
                    BorrowerId = dto.BorrowerId,
                    LoanDate = dto.LoanDate,
                    ReturnDate = dto.ReturnDate,
                };
                loan.Id = id;

                var updatedLoan = await _Service.UpdateLoan(loan);

                return Ok(updatedLoan);
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

        
    }
}
