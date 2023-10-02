using EngSchool.Contracts;
using EngSchool.Entities.Models;
using EngSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace EngSchool.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(EngSchoolRepositoryContext context): base(context)
        {
                
        }

        public void CreateUser(int positionId, User user)
        {
            user.PositionId = positionId;
            Create(user);
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }

        public async Task<PageList<User>> GetAllUsersAsync(int positionId,UserParameters userParameters, bool trackChanges)
        {
            var users = await FindByCondition(c => c.PositionId.Equals(positionId), trackChanges)
                .OrderBy(c => c.Name)
                .ToListAsync();
            return PageList<User>.ToPageList(users, userParameters.PageNumber, userParameters.PageSize);
        }

        public async Task<User> GetUserByIdAsync(int positionId, int userId, bool trackChanges)
        {
            return await FindByCondition(x => x.UserId.Equals(userId) && x.PositionId.Equals(positionId), trackChanges).SingleOrDefaultAsync();
        }

       
    }
}
