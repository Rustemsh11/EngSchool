using EngSchool.Contracts;
using EngSchool.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EngSchool.Repository
{
    public class CourseOfUsersRepository : RepositoryBase<CourseOfUsers>, ICourseOfUsersRepository
    {
        public CourseOfUsersRepository(EngSchoolRepositoryContext context) : base(context)
        {
        }

        public void CreateCourseOfUsers(CourseOfUsers courseOfUsers)
        {
            Create(courseOfUsers);
        }

        public void DeleteCourseOfUsers(CourseOfUsers courseOfUsers)
        {
            Delete(courseOfUsers);
        }

        public async Task<IEnumerable<CourseOfUsers>> GetCourseIdForConcreteUserAsync(int userId, bool trackChanges)
        {
            return await FindByCondition(c => c.UserId.Equals(userId), trackChanges).Include(c=>c.Course).ThenInclude(c=>c.Service).ToListAsync();
        }

        public async Task<CourseOfUsers> GetCourseOfUsers(int userId, int courseId, bool trackChanges)
        {
            return await FindByCondition(c => (c.UserId.Equals(userId) && c.CourseId.Equals(courseId)), trackChanges).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CourseOfUsers>> GetUsersForConcreteCourseAsync(int serviceId, int courseId, bool trackChanges)
        {
            return await FindByCondition(c => c.CourseId.Equals(courseId), trackChanges).Include(c => c.User).ToListAsync();    
        }
    }
}
