using EngSchool.Contracts;
using EngSchool.Entities.Models;

namespace EngSchool.Repository
{
    public class PriceRepository: RepositoryBase<Price>, IPriceRepository
    {
        public PriceRepository(EngSchoolRepositoryContext context): base(context)
        {
                
        }
    }
}
