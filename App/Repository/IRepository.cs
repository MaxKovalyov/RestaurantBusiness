using System;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetByIdAsync(Guid id);

        Task AddAsync(TEntity model);

        Task UpdateAsync(TEntity model);

        Task DeleteAsync(TEntity model);

        Task SaveChangesAsync();
    }
}
