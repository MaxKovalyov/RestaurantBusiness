using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBusiness.Models
{
    public class EventProducts
    {
        [ForeignKey("OrderEvent")]
        public Guid EventId { get; set; }

        public OrderEvent OrderEvent { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        public Product Product { get; set; }
    }
}
