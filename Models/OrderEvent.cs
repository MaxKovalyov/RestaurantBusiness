
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBusiness.Models
{
    public class OrderEvent : BaseModel
    {
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Range(4, 100, ErrorMessage = "Мероприятие рассчитано на кол-во людей от 4 до 100")]
        [Display(Name = "Количество гостей")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Недопустимые символы")]
        [Required(ErrorMessage = "Не введено количество гостей")]
        public int CountGuest { get; set; }

        [Display(Name = "Подробное описание заказа")]
        public string Description { get; set; }

        [MaxLength(50, ErrorMessage = "ФИО клиента не должно превышать 50 символов")]
        [Display(Name = "ФИО клиента")]
        [Required(ErrorMessage = "Не введено ФИО клиента")]
        [RegularExpression(@"^[A-ZА-ЯЁ]{1}[A-Za-zА-ЯЁа-яё]+ [A-ZА-ЯЁ]{1}[A-Za-zА-ЯЁа-яё]+ [A-ZА-ЯЁ]{1}[A-Za-zА-ЯЁа-яё]+$", ErrorMessage = "Недопустимые символы или неверный формат ФИО (Ф И О)")]
        public string ClientName { get; set; }

        [Display(Name = "Номер телефона клиента")]
        [Required(ErrorMessage = "Не введён номер телефона клиента")]
        [RegularExpression(@"^[0-9+() ]+$", ErrorMessage = "Недопустимые символы в номере телефона")]
        [MaxLength(15, ErrorMessage = "Максимальная длина номера 15 символов")]
        public string ClientPhone { get; set; }

        [Display(Name = "Ресторан")]
        [Required(ErrorMessage = "Не выбран ресторан")]
        public Guid RestaurantId { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public Restaurant Restaurant { get; set; }

        [Display(Name = "Стоимость мероприятия")]
        public decimal CostEvent { get; set; }

        public ICollection<EventProducts> EventProducts { get; set; }
    }
}
