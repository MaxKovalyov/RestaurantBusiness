
using System.Collections.Generic;

namespace RestaurantBusiness.Models
{
    public class OrderEvent : OrderTable
    {
        public decimal CostEvent { get; set; }

        public ICollection<EventProducts> EventProducts { get; set; }
    }
}
