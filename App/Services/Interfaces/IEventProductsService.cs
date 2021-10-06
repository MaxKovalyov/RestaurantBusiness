using RestaurantBusiness.Models;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Services
{
    public interface IEventProductsService
    {
        Task AddAsync(EventProducts model);

        Task DeleteAsync(EventProducts model);
    }
}
