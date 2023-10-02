using EngSchool.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Linq;

namespace EngSchool.Tests.Repositoryes.Helper
{
    public  class TestDataBaseContext
    {
        public EngSchoolRepositoryContext Context { get; set; }
        public TestDataBaseContext()
        {
            var builder = new DbContextOptionsBuilder<EngSchoolRepositoryContext>();
            builder.UseInMemoryDatabase(databaseName: "TestDataBaseContext")
                .ConfigureWarnings(x=>x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            var options = builder.Options;

            Context = new EngSchoolRepositoryContext(options);

            Context.AddRange(PositionHelper.GetManyPosition());
            Context.AddRange(UserHelper.GetManyUsers(5));
            Context.SaveChanges();

            
        }
    }
}
