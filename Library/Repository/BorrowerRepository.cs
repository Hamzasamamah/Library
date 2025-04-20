using Library.Data;
using Library.IRepository;
using Library.Model;

namespace Library.Repository
{
    public class BorrowerRepository : GenericRepository<Borrower>, IBorrowerRepository
    {
        public BorrowerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
