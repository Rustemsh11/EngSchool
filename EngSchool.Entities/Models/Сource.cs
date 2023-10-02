namespace EngSchool.Entities.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? Period { get; set; }
        public string? Level { get; set;}
        public int ServiceId { get; set; }
        public Service? Service { get; set; }
        public ICollection<Price>? Prices { get; set; }
        public ICollection<User>? Users { get; set; }
    }

}
