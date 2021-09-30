
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBusiness.Models
{
    public class OrderEvent : BaseModel
    {
        public DateTime Date { get; set; }

        [Range(4, 100, ErrorMessage = "Мероприятие рассчитано на кол-во людей от 4 до 100")]
        public int CountGuest { get; set; }
        public string Description { get; set; }

        [MaxLength(50, ErrorMessage = "ФИО клиента не должно превышать 50 символов")]
        public string ClientName { get; set; }

        public string ClientPhone { get; set; }

        public Guid RestaurantId { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public Restaurant Restaurant { get; set; }
        public decimal CostEvent { get; set; }

        public ICollection<EventProducts> EventProducts { get; set; }
    }
}
