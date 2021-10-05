using RestaurantBusiness.Models;
using System.Collections.Generic;

namespace RestaurantBusiness.App.ViewModels
{
    public class MenuViewModel
    {
        public List<Product> Products { get; set; }

        public List<Category> Categories { get; set; }

    }
}
