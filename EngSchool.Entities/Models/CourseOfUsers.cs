namespace EngSchool.Entities.Models
{
    public class CourseOfUsers
    {
        public int CourseOfUsersId { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }   
        public User? User { get; set; }
        public Course? Course { get; set; } 
    }

}
