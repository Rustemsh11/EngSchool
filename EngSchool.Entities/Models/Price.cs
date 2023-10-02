using System.ComponentModel.DataAnnotations;

namespace EngSchool.Entities.Models
{
    public class Price
    {
        public int PriceId { get; set; }
        [Required]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Введите стоимость")]
        [Range(0,int.MaxValue,ErrorMessage = "Цена не может быть меньше 0")]
        public decimal Cost { get; set; }
        public Course? Course { get; set; }
    }
}
