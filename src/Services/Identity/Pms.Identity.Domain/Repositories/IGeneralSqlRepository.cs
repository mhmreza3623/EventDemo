using System.Linq.Expressions;

namespace Identity.Domain.Repositories
{
    public interface IGeneralSqlRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> AllAsync();
        IQueryable<TEntity> AllAsync(int pageSize, int pageNumber);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predict);

    }
}
