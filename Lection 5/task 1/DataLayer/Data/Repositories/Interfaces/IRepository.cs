using DataLayer.Entities;

namespace DataLayer.Data.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : IEntity
{
    public Task<TEntity> Create(TEntity entity);

    public Task Delete(Guid Id);

    public Task<TEntity> Find(Guid Id);

    public IQueryable<TEntity> GetAll();

    public Task<TEntity> Update(TEntity entity);
}
