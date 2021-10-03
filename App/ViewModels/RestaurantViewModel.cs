using Microsoft.AspNetCore.Http;
using RestaurantBusiness.Models;
using System.Collections.Generic;

namespace RestaurantBusiness.App.ViewModels
{
    public class RestaurantViewModel
    {
        public List<Restaurant> Restaurants { get; set; }

        public Restaurant Restaurant { get; set; }

        public IFormFile File { get; set; }
    }
}
