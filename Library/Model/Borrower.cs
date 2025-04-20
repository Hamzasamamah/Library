
namespace Library.Model
{
    public class Borrower : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
     

        public ICollection<Loan> Loans { get; set; }=new List<Loan>();
    }
}
