using EngSchool.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EngSchool.Repository.Configuration
{
    public class CourseOfUsersConfiguration : IEntityTypeConfiguration<CourseOfUsers>
    {
        public void Configure(EntityTypeBuilder<CourseOfUsers> builder)
        {
            builder.Property(e=>e.CourseOfUsersId).ValueGeneratedOnAdd();
        }
    }
}
