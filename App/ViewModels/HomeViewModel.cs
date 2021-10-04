using RestaurantBusiness.Models;
using System.Collections.Generic;

namespace RestaurantBusiness.App.ViewModels
{
    public class HomeViewModel
    {
        public List<Restaurant> Restaurants { get; set; }

        public List<News> News { get; set; }

        public PageViewModel PageModel { get; set; }
    }
}
