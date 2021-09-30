
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantBusiness.Models
{
    public class Category: BaseModel
    {
        [MaxLength(20, ErrorMessage = "Название категории не должно превышать 20 символов")]
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
