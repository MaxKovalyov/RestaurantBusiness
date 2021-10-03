using Microsoft.AspNetCore.Http;
using RestaurantBusiness.Models;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Services
{
    public interface IRestaurantService: IServices<Restaurant>
    {
        Task UploadFile(IFormFile file, string path);

        Task Update(Restaurant model, IFormFile file);

        Task AddAsync(Restaurant model, IFormFile file);

        void DeleteFile(string path);
    }
}
