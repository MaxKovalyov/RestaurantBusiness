using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBusiness.Models
{
    public class EventProducts
    {
        public Guid EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public OrderEvent OrderEvent { get; set; }

        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public ICollection<Product> Products { get; set; }
    }
}
