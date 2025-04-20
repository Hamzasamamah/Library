namespace Library.DTOs
{
    public class CreateLoanDto
    {
        public Guid BorrowerId { get; set; }
        public Guid BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
