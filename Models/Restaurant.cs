using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantBusiness.Models
{
    public class Restaurant : BaseModel
    {
        [RegularExpression(@"^[A-Za-zА-ЯЁа-яё""' ]+$", ErrorMessage = "Недопустимые символы в названии")]
        [Required(ErrorMessage = "Название ресторана не введено")]
        [Display(Name = "Название ресторана")]
        [MaxLength(20, ErrorMessage = "Название ресторана не должно превышать 20 символов")]
        public string Title { get; set; }

        public string Image { get; set; }

        [Display(Name = "Расположение ресторана")]
        [MaxLength(40, ErrorMessage = "Адрес не должен превышать 40 символов")]
        [RegularExpression(@"^[A-Za-zА-ЯЁа-яё0-9., ]+$", ErrorMessage = "Недопустимые символы")]
        public string Adress { get; set; }

        public ICollection<OrderTable> TableOrders { get; set; }

        public ICollection<OrderEvent> EventOrders { get; set; }
    }
}
