using System;

namespace RestaurantBusiness.Models
{
    public class Review: BaseModel
    {
        public DateTime Date { get; set; }

        public string Content { get; set; }

        public string CreatorName { get; set; }
    }
}
