namespace EngSchool.Entities.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string? ServiceName { get; set; }

        public ICollection<Course>? Cources { get; set; }
    }
}
