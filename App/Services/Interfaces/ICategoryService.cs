using RestaurantBusiness.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategory();

        Task AddAsync(Category model);

        Task Update(Category model);

        Task DeleteAsync(Guid id);

        Task<Category> GetByIdAsync(Guid id);
    }
}
