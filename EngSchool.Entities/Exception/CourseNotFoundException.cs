namespace EngSchool.Entities.Exception
{
    public class CourseNotFoundException : NotFoundException
    {
        public CourseNotFoundException(int id) : base($"Course with {id} not found in database")
        {
        }
    }
}
