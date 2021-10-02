using RestaurantBusiness.Models;
using System.Collections.Generic;

namespace RestaurantBusiness.App.ViewModels
{
    public class NewsViewModel
    {
        public List<News> News { get; set; }

        public News OneNews { get; set; }
    }
}
