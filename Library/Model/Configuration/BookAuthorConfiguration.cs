using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Model.Configuration
{
    public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(b => b.Book)
                   .WithMany(ba => ba.BookAuthors)  
                   .HasForeignKey(ba => ba.BookId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Author)
                   .WithMany(ba => ba.BookAuthors)
                   .HasForeignKey(a => a.AuthorId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(ba => ba.Created)
                   .IsRequired()
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(ba => ba.Updated)
                  .IsRequired()
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
