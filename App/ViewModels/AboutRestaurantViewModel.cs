using RestaurantBusiness.Models;
using System.Collections.Generic;

namespace RestaurantBusiness.App.ViewModels
{
    public class AboutRestaurantViewModel
    {
        public List<Restaurant> Restaurants { get; set; }

        public PageViewModel PageModel { get; set; }
    }
}
