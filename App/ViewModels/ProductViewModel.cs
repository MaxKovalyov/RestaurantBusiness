using Microsoft.AspNetCore.Http;
using RestaurantBusiness.Models;
using System.Collections.Generic;

namespace RestaurantBusiness.App.ViewModels
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }
        public Product Product { get; set; }
        public IFormFile File { get; set; }
        public PageViewModel PageModel { get; set; }
    }
}
