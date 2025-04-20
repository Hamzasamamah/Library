
namespace Library.Model
{
    public class Loan : BaseEntity
    {
        public Guid BorrowerId { get; set; }
        public Guid BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }


        public Borrower Borrower { get; set; }
        public Book Book { get; set; }
    }
}
