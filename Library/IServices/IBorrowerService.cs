using Library.DTOs;
using Library.Model;

namespace Library.IServices
{
    public interface IBorrowerService
    {
        Task<IEnumerable<Borrower>> GetAllBorrowers();
        Task<Borrower> GetBorrowerById(Guid id);
        Task<Borrower> CreateBorrower(CreateBorrowerDto entity);
        Task<Borrower> UpdateBorrower(Borrower entity);
        Task<bool> DeleteBorrower(Guid id);
    }
}
