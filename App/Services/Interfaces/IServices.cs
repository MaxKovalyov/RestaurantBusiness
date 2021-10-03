using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Services
{
    public interface IServices<TEntity> where TEntity: class
    {
        Task<List<TEntity>> GetAll();

        Task AddAsync(TEntity model);

        Task Update(TEntity model);

        Task DeleteAsync(Guid id);

        Task<TEntity> GetByIdAsync(Guid id);
    }
}
