using DataLayer.Data.Repositories.Interfaces;
using DataLayer.Entities;
using task_1.Data.Infrastructure;

namespace DataLayer.Data.Repositories.Realization
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        private readonly WebStorageDbContext _dbContext;

        public Repository(WebStorageDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            var createdEntity = await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task Delete(Guid Id)
        {
            var deleteEntity = _dbContext.Set<TEntity>().Find(Id);
            if (deleteEntity != null)
            {
                _dbContext.Set<TEntity>().Remove(deleteEntity);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> Find(Guid Id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(Id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var updatedEntity = _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return updatedEntity.Entity;
        }
    }
}
