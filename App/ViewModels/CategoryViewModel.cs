using RestaurantBusiness.Models;
using System.Collections.Generic;

namespace RestaurantBusiness.App.ViewModels
{
    public class CategoryViewModel
    {
        public List<Category> Categories { get; set; }

        public Category Category { get; set; }
    }
}
