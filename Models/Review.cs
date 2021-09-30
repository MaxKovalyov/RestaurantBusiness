using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantBusiness.Models
{
    public class Review: BaseModel
    {
        public DateTime Date { get; set; }

        public string Content { get; set; }

        [MaxLength(40, ErrorMessage = "Имя не должно превышать 40 символов")]
        public string CreatorName { get; set; }
    }
}
