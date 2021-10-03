using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantBusiness.Models
{
    public class Review: BaseModel
    {
        [Display(Name = "Дата добавления")]
        public DateTime Date { get; set; }

        [Display(Name = "Содержание отзыва")]
        public string Content { get; set; }

        [Display(Name = "Имя создателя отзыва")]
        [MaxLength(40, ErrorMessage = "Имя не должно превышать 40 символов")]
        [Required(ErrorMessage = "Имя создателя не введено")]
        [RegularExpression(@"^[A-Za-zА-ЯЁа-яё ]+$", ErrorMessage = "Недопустимые символы в имени")]
        public string CreatorName { get; set; }
    }
}
