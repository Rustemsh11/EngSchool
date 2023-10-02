using System.ComponentModel.DataAnnotations;

namespace EngSchool.Entities.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Имя является обязательным полем")]
        [MaxLength(30, ErrorMessage = "Имя не должно превышать 30 символов")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Возраст является обязательным полем")]
        [Range(1, 120, ErrorMessage = "Возраст не может быть меньше 1 и больше 120")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Почта является обязательным полем")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? Email { get; set; }
        public string? Adress { get; set; }
        [Required(ErrorMessage = "Номер телефона является обязательным полем")]
        public string? Phone { get; set; }
        public int PositionId { get; set; }
        public Position? Position { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}
