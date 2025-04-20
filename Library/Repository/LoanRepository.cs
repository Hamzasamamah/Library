using Library.Data;
using Library.IRepository;
using Library.Model;

namespace Library.Repository
{
    public class LoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        public LoanRepository(AppDbContext context) : base(context)
        {
        }
    }
}
