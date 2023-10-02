using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EngSchool.Repository.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                    new IdentityRole
                    {
                        Name = "Учитель",
                        NormalizedName = "TEACHER",
                    },
                    new IdentityRole
                    {
                        Name = "Ученик",
                        NormalizedName = "STUDENT"
                    },
                    new IdentityRole
                    {
                        Name = "Админ",
                        NormalizedName = "ADMIN"
                    }
                );
        }
    }
}
