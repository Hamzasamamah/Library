using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Model.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            

            builder.Property(x=>x.UserName).HasMaxLength(30).IsRequired();

            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();

            builder.Property(x => x.Password).HasMaxLength(256).IsRequired();

            builder.Property(x => x.Phone).HasMaxLength(10).IsRequired();

            builder.Property(ba => ba.Created)
                  .IsRequired()
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(ba => ba.Updated)
                  .IsRequired()
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(u => u.Role)  
                  .WithMany(r => r.Users)
                  .HasForeignKey(u => u.RoleId) 
                  .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
