using EngSchool.Entities.Models;
using EngSchool.Repository.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EngSchool.Repository
{
    public class EngSchoolRepositoryContext: IdentityDbContext<AuthUser>
    {
        public EngSchoolRepositoryContext(DbContextOptions options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PositionsConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new PriceConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<CourseOfUsers> CourseOfUsers { get; set; }
    }
}
