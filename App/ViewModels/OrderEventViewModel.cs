using RestaurantBusiness.Models;
using System;
using System.Collections.Generic;

namespace RestaurantBusiness.App.ViewModels
{
    public class OrderEventViewModel
    {
        public List<OrderEvent> EventOrders { get; set; }

        public List<Product> Products { get; set; }

        public OrderEvent OrderEvent { get; set; }

        public List<Guid> OrderedProducts { get; set; }

        public PageViewModel PageModel { get; set; }
    }
}
