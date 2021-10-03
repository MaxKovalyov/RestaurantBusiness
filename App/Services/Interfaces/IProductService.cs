using Microsoft.AspNetCore.Http;
using RestaurantBusiness.Models;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Services
{
    public interface IProductService: IServices<Product>
    {
        Task Update(Product model, IFormFile file);

        Task AddAsync(Product model, IFormFile file);
    }
}
