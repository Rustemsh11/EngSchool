using EngSchool.Entities.Models;
using EngSchool.Shared.RequestFeatures;

namespace EngSchool.Contracts
{
    public interface IUserRepository
    {
        Task<PageList<User>> GetAllUsersAsync(int positionId, UserParameters userParameters, bool trackChanges);
        Task<User> GetUserByIdAsync(int positionId,int userId, bool trackChanges);
        void CreateUser(int positionId, User user);
        void DeleteUser(User user);
        //Task<IEnumerable<Course>> GetUserCoursesByIdAsync(int positionId, int userId, bool trackChages);
    }
}
