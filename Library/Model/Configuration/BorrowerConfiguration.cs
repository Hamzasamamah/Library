using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Model.Configuration
{
    public class BorrowerConfiguration : IEntityTypeConfiguration<Borrower>
    {
        public void Configure(EntityTypeBuilder<Borrower> builder)
        {
            builder.HasKey(x => x.Id);
            

            builder.Property(x=>x.Name).HasMaxLength(30).IsRequired();

            builder.Property(x=>x.Email).HasMaxLength(100).IsRequired();

            builder.Property(x=>x.Phone).HasMaxLength(10).IsRequired();

            builder.Property(ba => ba.Created)
                   .IsRequired()
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(ba => ba.Updated)
                  .IsRequired()
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
