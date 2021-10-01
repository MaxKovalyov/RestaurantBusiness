
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantBusiness.Models
{
    public class Category: BaseModel
    {
        [Display(Name = "Название категории")]
        [MaxLength(20, ErrorMessage = "Название категории не должно превышать 20 символов")]
        [RegularExpression(@"^[A-Za-zА-ЯЁа-яё ]+$", ErrorMessage = "Недопустимые символы в названии")]
        [Required(ErrorMessage = "Не введено название категории")]
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
