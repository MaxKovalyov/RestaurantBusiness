using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantBusiness.Models
{
    public class Restaurant : BaseModel
    {
        [MaxLength(20, ErrorMessage = "Название ресторана не должно превышать 20 символов")]
        public string Title { get; set; }

        public string Image { get; set; }

        [MaxLength(40, ErrorMessage = "Адрес не должен превышать 40 символов")]
        public string Adress { get; set; }

        public ICollection<OrderTable> TableOrders { get; set; }

        public ICollection<OrderEvent> EventOrders { get; set; }
    }
}
