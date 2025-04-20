using Library.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Seeder
{
    public class RoleSeeder : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    Id = Guid.Parse("c56a4180-65aa-42ec-a945-5fd21dec0538"),
                    Name = "Admin"
                },
                new Role
                {
                    Id = Guid.Parse("c56a4180-65aa-42ec-a945-5fd21dec0545"),
                    Name = "User"
                }
            );
        }
    }
}
