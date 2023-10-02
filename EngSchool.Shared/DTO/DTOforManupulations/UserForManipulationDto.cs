using System.ComponentModel.DataAnnotations;

namespace EngSchool.Shared.DTO.DTOforManupulations
{
    public abstract record UserForManipulationDto
    {
        [Required(ErrorMessage = "Имя является обязательным полем")]
        [MaxLength(30, ErrorMessage = "Имя не должно превышать 30 символов")]
        public string? Name { get; init; }
        [Required(ErrorMessage = "Возраст является обязательным полем")]
        [Range(1, 120, ErrorMessage = "Возраст не может быть меньше 1 и больше 120")]
        public int Age { get; init; }
        [Required(ErrorMessage = "Почта является обязательным полем")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? Email { get; init; }
        public string? Adress { get; init; }
        [Required(ErrorMessage = "Номер телефона является обязательным полем")]
        public string? Phone { get; init; }
    }
}
