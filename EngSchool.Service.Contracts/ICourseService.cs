using EngSchool.Entities.Models;
using EngSchool.Shared.DTO;
using EngSchool.Shared.DTO.UpdateDTO;
using EngSchool.Shared.RequestFeatures;

namespace EngSchool.Service.Contracts
{
    public interface ICourseService
    {
        Task<(IEnumerable<CourseDto> courseDto, MetaData metaData)> GetAllCoursesAsync(int serviceId, CourseParameters courseParameters, bool trackChanges);
        Task<CourseDto> GetCourseAsync(int serviceId, int courseId, bool trackChanges);
        Task<CourseDto> CreateCourseAsync(int serviceId, CourseCreateDto course, bool trackChanges);
        Task DeleteCourse(int serviceId, int courseId, bool trackChanges);
        Task<IEnumerable<UserDto>> GetUsersForCourseByIdAsync(int serviceId, int courseId, bool trackChanges);
        Task UpdateCourseAsync(int serviceId, int courseId, CoursesUpdateDto coursesUpdate, bool trackChangesForService, bool trackChangesForCourse);
        Task<(CoursesUpdateDto courseToPatch, Course courseEntity)> GetCourseForPatchAsync(int serviceId, int courseId, bool trackChangesForService, bool trackChangesForCourse);
        Task SaveChangesForPatchAsync(CoursesUpdateDto courseToPatch, Course courseEntity);
    }
}
