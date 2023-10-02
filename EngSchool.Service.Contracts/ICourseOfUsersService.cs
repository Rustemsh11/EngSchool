using EngSchool.Shared.DTO;

namespace EngSchool.Service.Contracts
{
    public interface ICourseOfUsersService
    {
        Task<CreateCourseOfUsersDto> CreateCourseOfUsersAsync(CreateCourseOfUsersDto courseOfUsersDto, bool trackChanges);
        Task DeleteCourseOfUsersAsync(CourseOfUsersDto courseOfUsersDto, bool trackChanges);
    }
}
