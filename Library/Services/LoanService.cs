using Library.DTOs;
using Library.IRepository;
using Library.IServices;
using Library.Model;

namespace Library.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _repository;
        public LoanService(ILoanRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Loan>> GetAllLoans()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Loan> GetLoanById(Guid id)
        {
            var loan = await _repository.GetByIdAsync(id);
            if (loan == null)
            {
                throw new KeyNotFoundException($"Loan with ID {id} not found.");
            }
            return loan;
        }

        public async Task<Loan> CreateLoan(CreateLoanDto dto)
        {
            var entity = new Loan
            {
                BookId = dto.BookId,
                BorrowerId = dto.BorrowerId,
                LoanDate = dto.LoanDate,
                ReturnDate = dto.ReturnDate,
            };
            return await _repository.AddAsync(entity);
        }

        public async Task<Loan> UpdateLoan(Loan entity)
        {
            var loan = await _repository.GetByIdAsync(entity.Id);
            if (loan == null)
            {
                throw new KeyNotFoundException($"Loan with ID {entity.Id} not found.");
            }

            loan.BorrowerId = entity.BorrowerId;
            loan.BookId = entity.BookId;
            loan.LoanDate = entity.LoanDate;
            loan.ReturnDate = entity.ReturnDate;
            loan.Updated = DateTime.UtcNow;
            
            return await _repository.UpdateAsync(loan);
        }

        public async Task<bool> DeleteLoan(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

    }
}
