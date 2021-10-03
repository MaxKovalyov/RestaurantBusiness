using Microsoft.AspNetCore.Http;
using RestaurantBusiness.Models;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Services
{
    public interface IRestaurantService: IServices<Restaurant>
    {
        Task Update(Restaurant model, IFormFile file);

        Task AddAsync(Restaurant model, IFormFile file);
    }
}
