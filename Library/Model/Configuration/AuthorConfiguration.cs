using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Model.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder) 
        {
            builder.HasKey(x => x.Id);
            

            builder.Property(a=>a.Name).HasMaxLength(30).IsRequired();

            builder.Property(a=>a.Bio).HasMaxLength(100);

            builder.Property(ba => ba.Created)
                   .IsRequired()
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(ba => ba.Updated)
                  .IsRequired()
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");


        }
    }
}
