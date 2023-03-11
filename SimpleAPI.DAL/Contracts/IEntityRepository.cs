using System.Linq.Expressions;

namespace SimpleAPI.DAL.Contracts
{
    public interface IEntityRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id, bool trackable);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task<int> CountAsync();
        Task<int> SaveChangesAsync();
    }
}
