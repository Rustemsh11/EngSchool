using EngSchool.Entities.Models;

namespace EngSchool.Repository.Extensions
{
    public static class CourseRepositoryExtensions
    {
        public static IQueryable<Course> Filter(this IQueryable<Course> courses, string courseLevel)
        {
            if (string.IsNullOrWhiteSpace(courseLevel))
            {
                return courses;
            }
            return courses.Where(c => c.Level.ToLower() == courseLevel.ToLower());
        } 

        public static IQueryable<Course> Search(this IQueryable<Course> courses, string searchName)
        {
            if (string.IsNullOrWhiteSpace(searchName))
            {
                return courses;
            }
            return courses.Where(c => c.CourseName.ToLower().Contains(searchName.ToLower()));
        }
    }
}
