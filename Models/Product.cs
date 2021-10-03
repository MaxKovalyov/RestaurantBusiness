using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBusiness.Models
{
    public class Product : BaseModel
    {
        [RegularExpression(@"^[A-Za-zА-ЯЁа-яё""' ]+$", ErrorMessage = "Недопустимые символы в названии")]
        [Required(ErrorMessage = "Название блюда не введено")]
        [Display(Name = "Название блюда")]
        [MaxLength(40, ErrorMessage = "Название блюда не должно превышать 40 символов")]
        public string Title { get; set; }

        public string Image { get; set; }

        [RegularExpression(@"^[0-9]+[,]{1}[0-9]+$", ErrorMessage = "Неверный формат вещественного числа (xxx,xxx)")]
        [Range(0, 999999, ErrorMessage = "Стоимость не может быть отрицательной или превышать 999999")]
        [Display(Name = "Стоимость блюда, ₽")]
        [Required(ErrorMessage = "Стоимость блюда не введена")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Категория не выбрана")]
        [Display(Name = "Категория блюда")]
        public Guid CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public ICollection<EventProducts> EventProducts { get; set; }

    }
}
