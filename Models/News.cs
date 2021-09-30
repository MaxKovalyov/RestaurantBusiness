using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantBusiness.Models
{
    public class News: BaseModel
    {
        public DateTime Date { get; set; }

        [MaxLength(50, ErrorMessage ="Длина краткого описания не должна превышать 50 символов")]
        public string Description { get; set; }

        public string Content { get; set; }
    }
}
