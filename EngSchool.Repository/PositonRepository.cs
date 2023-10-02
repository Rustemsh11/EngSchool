using EngSchool.Contracts;
using EngSchool.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EngSchool.Repository
{
    public class PositonRepository : RepositoryBase<Position>, IPositionRepository
    {
       
        public PositonRepository(EngSchoolRepositoryContext context) : base(context)
        {
        }

        public void CreatePosition(Position position)
        {
            Create(position);
        }

        public async Task<IEnumerable<Position>> GetAllPositionAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c=>c.PositionName).ToListAsync();
        }

        public async Task<Position> GetPositionAsync(int id, bool trackChanges)
        {

           
            return await FindByCondition(c => c.PositionId.Equals(id), trackChanges).SingleOrDefaultAsync();
        }
    }
}
