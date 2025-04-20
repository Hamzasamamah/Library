using Library.DTOs;
using Library.Model;

namespace Library.IServices
{
    public interface ILoanService
    {
        Task<IEnumerable<Loan>> GetAllLoans();
        Task<Loan> GetLoanById(Guid id);
        Task<Loan> CreateLoan(CreateLoanDto entity);
        Task<Loan> UpdateLoan(Loan entity);
        Task<bool> DeleteLoan(Guid id);
    }
}
