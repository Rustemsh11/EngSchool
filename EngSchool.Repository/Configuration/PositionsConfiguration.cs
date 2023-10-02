using EngSchool.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EngSchool.Repository.Configuration
{
    public class PositionsConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(e => e.CourseId).ValueGeneratedOnAdd();
        }
    }
}
