using EngSchool.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EngSchool.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<EngSchoolRepositoryContext>
    {
        public EngSchoolRepositoryContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<EngSchoolRepositoryContext>()
                .UseSqlServer(config.GetConnectionString("sqlConnection"), b=>b.MigrationsAssembly("EngSchool"));
            return new EngSchoolRepositoryContext(builder.Options);
        }
    }
}
