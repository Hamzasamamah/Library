using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Model.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            

            builder.Property(x=>x.Name).HasMaxLength(30);

            builder.Property(ba => ba.Created)
                  .IsRequired()
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(ba => ba.Updated)
                  .IsRequired()
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
