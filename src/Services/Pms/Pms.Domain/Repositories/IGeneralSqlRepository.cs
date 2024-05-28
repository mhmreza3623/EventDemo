using System.Linq.Expressions;
using SharedKernel.Common.SqlModels;

namespace Pms.Domain.Repositories
{
    public interface IGeneralSqlRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> AllAsync();
        IQueryable<TEntity> AllAsync(int pageSize, int pageNumber);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predict);
        Task<TEntity?> GetAsync(Guid uxId);
        Task InsertAsync(TEntity client);
        Task UpdateAsync(TEntity entity);
    }
}
