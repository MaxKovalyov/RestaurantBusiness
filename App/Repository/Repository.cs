using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantBusiness.App.Repository
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity : class
    {
        protected DbContext DbContext { get; }

        protected DbSet<TEntity> DbSet { get; }

        public Repository(DbContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            await DbSet.AddAsync(model);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            DbSet.Remove(model);
            await SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            DbSet.Update(model);
            await SaveChangesAsync();
        }
    }
}
