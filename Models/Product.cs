using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBusiness.Models
{
    public class Product : BaseModel
    {
        [MaxLength(40, ErrorMessage = "Название блюда не должно превышать 40 символов")]
        public string Title { get; set; }

        public string Image { get; set; }

        [Range(0, 999999, ErrorMessage = "Стоимость не может быть отрицательной или превышать 999999")]
        public decimal Cost { get; set; }

        public Guid CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

    }
}
