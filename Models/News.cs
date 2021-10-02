using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantBusiness.Models
{
    public class News: BaseModel
    {
        [Display(Name = "Дата события")]
        public DateTime Date { get; set; }

        [Display(Name = "Описание новости")]
        [MaxLength(50, ErrorMessage ="Длина краткого описания не должна превышать 50 символов")]
        [RegularExpression(@"^[A-Za-zА-ЯЁа-яё0-9 ]+$", ErrorMessage = "Недопустимые символы в описании")]
        [Required(ErrorMessage = "Описание новости не введено")]
        public string Description { get; set; }

        [Display(Name = "Подробности новости")]
        public string Content { get; set; }
    }
}
