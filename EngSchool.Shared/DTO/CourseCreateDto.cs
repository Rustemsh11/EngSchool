using System.ComponentModel.DataAnnotations;

namespace EngSchool.Shared.DTO
{
    public record CourseCreateDto
    {
        [Required(ErrorMessage = "Course name is a required fields")]
        public string? CourseName { get; init; }
        [Required(ErrorMessage = "Period is a required fields")]
        public string? Period { get; init; }
        [Required(ErrorMessage = "Level is a required fields")]
        public string? Level { get; init; }
    }
}
