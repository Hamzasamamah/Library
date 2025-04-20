using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Model.Configuration
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasKey(x => x.Id);
            

            builder.HasOne(b => b.Borrower)
                   .WithMany(ba => ba.Loans)
                   .HasForeignKey(ba => ba.BorrowerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Book)
                   .WithMany(ba => ba.Loans)
                   .HasForeignKey(ba => ba.BookId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(ba => ba.LoanDate)
                  .IsRequired()
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(ba => ba.Created)
                  .IsRequired()
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(ba => ba.Updated)
                  .IsRequired()
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
