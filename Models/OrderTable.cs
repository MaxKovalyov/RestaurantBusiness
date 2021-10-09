using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBusiness.Models
{
    public class OrderTable: BaseModel
    {
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Display(Name = "Количество гостей")]
        [Range(1,6, ErrorMessage = "Столик вмещает от 1 до 6 гостей")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Недопустимые символы")]
        [Required(ErrorMessage = "Не введено количество гостей")]
        public int CountGuest { get; set; }

        [Display(Name = "Подробное описание заказа")]
        public string Description { get; set; }

        [Display(Name = "ФИО клиента")]
        [MaxLength(50, ErrorMessage = "ФИО клиента не должно превышать 50 символов")]
        [Required(ErrorMessage = "Не введено ФИО клиента")]
        [RegularExpression(@"^[A-ZА-ЯЁ]{1}[A-Za-zА-ЯЁа-яё]+ [A-ZА-ЯЁ]{1}[A-Za-zА-ЯЁа-яё]+ [A-ZА-ЯЁ]{1}[A-Za-zА-ЯЁа-яё]+$", ErrorMessage = "Недопустимые символы или неверный формат ФИО (Ф И О)")]
        public string ClientName { get; set; }

        [Display(Name = "Номер телефона клиента")]
        [Required(ErrorMessage = "Не введён номер телефона клиента")]
        [RegularExpression(@"^[0-9+() ]+$", ErrorMessage = "Недопустимые символы в номере телефона")]
        [Range(8, 15, ErrorMessage = "Длина номера от 8 до 15 цифр")]
        public string ClientPhone { get; set; }

        [Display(Name = "Ресторан")]
        [Required(ErrorMessage = "Не выбран ресторан")]
        public Guid RestaurantId { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public Restaurant Restaurant { get; set; }

    }
}
