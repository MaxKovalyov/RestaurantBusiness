using RestaurantBusiness.Models;
using System.Collections.Generic;

namespace RestaurantBusiness.App.ViewModels
{
    public class ReviewViewModel
    {
        public List<Review> Reviews { get; set; }

        public Review Review { get; set; }

        public PageViewModel PageModel { get; set; }

        public bool IsEven { get; set; }
    }
}
