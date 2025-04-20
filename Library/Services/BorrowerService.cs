using Library.DTOs;
using Library.IRepository;
using Library.IServices;
using Library.Model;

namespace Library.Services
{
    public class BorrowerService : IBorrowerService
    {
        private readonly IBorrowerRepository _repository;
        public BorrowerService(IBorrowerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Borrower>> GetAllBorrowers()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Borrower> GetBorrowerById(Guid id)
        {
            var borrower = await _repository.GetByIdAsync(id);
            if (borrower == null)
            {
                throw new KeyNotFoundException($"Borrower with ID {id} not found.");
            }
            return borrower;
        }

        public async Task<Borrower> CreateBorrower(CreateBorrowerDto dto)
        {
            var entity = new Borrower
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone

            };
            return await _repository.AddAsync(entity);
        }

        public async Task<Borrower> UpdateBorrower(Borrower entity)
        {
            var borrower = await _repository.GetByIdAsync(entity.Id);
            if (borrower == null)
            {
                throw new KeyNotFoundException($"Borrower with ID {entity.Id} not found.");
            }
            borrower.Name = entity.Name;
            borrower.Email = entity.Email;
            borrower.Phone = entity.Phone;
            borrower.Updated= DateTime.UtcNow;

            return await _repository.UpdateAsync(borrower);
        }

        public async Task<bool> DeleteBorrower(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

    }
}
