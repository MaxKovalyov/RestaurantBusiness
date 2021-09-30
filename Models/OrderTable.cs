using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBusiness.Models
{
    public class OrderTable: BaseModel
    {
        public DateTime Date { get; set; }
        public int CountGuest { get; set; }
        public string Description { get; set; }

        [MaxLength(50, ErrorMessage = "ФИО клиента не должно превышать 50 символов")]
        public string ClientName { get; set; }

        public string ClientPhone { get; set; }

        public Guid RestaurantId { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public Restaurant Restaurant { get; set; }

    }
}
