using EngSchool.Entities.Models;
using EngSchool.Shared.DTO;
using EngSchool.Shared.DTO.UpdateDTO;
using EngSchool.Shared.RequestFeatures;

namespace EngSchool.Service.Contracts
{
    public interface IUserService
    {
        Task<(IEnumerable<UserDto> userDto, MetaData metaData)> GetAllUsersAsync(int positionId, UserParameters userParameters, bool trackChanges);
        Task<UserDto> GetUserByIdAsync(int positionId,int userId, bool trackChanges);
        Task<UserDto> CreateUserAsync(int positionId, UserCreateDto userCreateDto, bool trackChanges);
        Task DeleteUserAsync(int positionId, int userId, bool trackChanges);
        Task<IEnumerable<CourseDto>> GetUserCoursesByIdAsync(int positionId,int userId, bool trackChages);
        Task UpdateUserAsync(int positionId, int userId, UserUpdateDto userUpdateDto, bool trackChangesForPosition, bool trackChangesForUser);
        Task<(UserUpdateDto userToPatch, User userEntity)> GetUserForPatch(int positionId, int userId, bool trackChangesForPosition, bool trackChangesForUser);
        Task SaveChangesForPatch(UserUpdateDto userToPatch, User userEntity);
    }
}
