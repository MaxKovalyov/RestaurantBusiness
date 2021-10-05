using RestaurantBusiness.Models;
using System.Collections.Generic;

namespace RestaurantBusiness.App.ViewModels
{
    public class OrderTableViewModel
    {
        public List<OrderTable> TableOrders { get; set; }

        public OrderTable OrderTable { get; set; }

        public PageViewModel PageModel { get; set; }
    }
}
