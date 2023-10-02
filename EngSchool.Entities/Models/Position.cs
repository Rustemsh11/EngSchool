using System.ComponentModel.DataAnnotations;

namespace EngSchool.Entities.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        [Required(ErrorMessage = "Название должности обязательное поле")]
        public string? PositionName { get; set; }

        public ICollection<User>? User { get; set; }

    }
}
