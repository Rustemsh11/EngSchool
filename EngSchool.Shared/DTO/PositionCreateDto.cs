using System.ComponentModel.DataAnnotations;

namespace EngSchool.Shared.DTO
{
    public record PositionCreateDto 
    {
        [Required(ErrorMessage = "Имя должности является обязательным полем")]
        [MaxLength(30, ErrorMessage = "Имя не должно превышать 30 символов")]
        public string? PositionName { get; init; }
    }
}
