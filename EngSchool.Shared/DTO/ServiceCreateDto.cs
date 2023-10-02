using System.ComponentModel.DataAnnotations;

namespace EngSchool.Shared.DTO
{
    public record ServiceCreateDto
    {
        [Required(ErrorMessage = "Имя сервиса является обязательным полем")]
        [MaxLength(30, ErrorMessage = "Имя не должно превышать 30 символов")]
        public string? ServiceName { get; init; }
        public IEnumerable<CourseCreateDto>? Courses { get; init; }
    }
    
}
