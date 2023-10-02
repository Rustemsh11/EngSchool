using EngSchool.Contracts;
using EngSchool.Entities.Models;
using EngSchool.Repository.Extensions;
using EngSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace EngSchool.Repository
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(EngSchoolRepositoryContext context):base(context)
        {
            
        }

        public void CreateCourse(int serviceId, Course course)
        {
            course.ServiceId = serviceId;
            Create(course);
        }

        public void DeleteCourse(Course course)
        {
            Delete(course);
        }

        public async Task<PageList<Course>> GetAllCoursesAsync(int serviceId,CourseParameters courseParameters, bool trackChanges)
        {
            var courses = await FindByCondition(c=>c.ServiceId.Equals(serviceId),trackChanges)
                .Filter(courseParameters.CourseLevel)
                .Search(courseParameters.CourseNameForSearch)
                .OrderBy(c=>c.CourseName)
                .ToListAsync();
            return PageList<Course>.ToPageList(courses, courseParameters.PageNumber, courseParameters.PageSize);
        }

        public async Task<Course> GetCourseAsync(int serviceId, int courseId, bool trackChanges)
        {
            return await FindByCondition(c => c.ServiceId.Equals(serviceId) && c.CourseId.Equals(courseId), trackChanges).SingleOrDefaultAsync();
        }
    }
}
