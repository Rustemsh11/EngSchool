using EngSchool.Entities.Models;

namespace EngSchool.Contracts
{
    public interface ICourseOfUsersRepository
    {
        void CreateCourseOfUsers(CourseOfUsers courseOfUsers);
        void DeleteCourseOfUsers(CourseOfUsers courseOfUsers);
        Task<IEnumerable<CourseOfUsers>> GetCourseIdForConcreteUserAsync(int userId, bool trackChanges);
        Task<IEnumerable<CourseOfUsers>> GetUsersForConcreteCourseAsync(int serviceId, int courseId, bool trackChanges);
        Task<CourseOfUsers> GetCourseOfUsers(int userId, int courseId, bool trackChanges);
    }
}
