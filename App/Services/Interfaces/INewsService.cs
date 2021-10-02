using RestaurantBusiness.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Services
{
    public interface INewsService
    {
        Task<List<News>> GetAllNews();

        Task AddAsync(News model);

        Task Update(News model);

        Task DeleteAsync(Guid id);

        Task<News> GetByIdAsync(Guid id);
    }
}
