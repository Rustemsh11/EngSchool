using EngSchool.Entities.Models;
using EngSchool.Shared.RequestFeatures;

namespace EngSchool.Contracts
{
    public interface ICourseRepository
    {
        Task<PageList<Course>> GetAllCoursesAsync(int serviceId, CourseParameters courseParameters, bool trackChanges);
        Task<Course> GetCourseAsync(int serviceId,int courseId, bool trackChanges);
        void CreateCourse(int serviceId, Course course);
        void DeleteCourse(Course course);
    }
}
