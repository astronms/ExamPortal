using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamPortal.Configuration.Entities
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                    Id = "9a48d905-08ad-4548-8da3-b168be98b43a"
                },
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    Id = "d98f3528-5b3b-429c-b82d-a30df84f17da"
                },
                new IdentityRole
                {
                    Name = "SuperAdministrator",
                    NormalizedName = "SUPERADMINISTRATOR",
                    Id = "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd"
                }
            );
        }
    }
}
