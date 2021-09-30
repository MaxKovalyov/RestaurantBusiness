
using System.Collections.Generic;

namespace RestaurantBusiness.Models
{
    public class Category: BaseModel
    {
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
