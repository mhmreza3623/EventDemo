using System.Linq.Expressions;
using DataBase.Core;
using Pms.Infrastructure.Persistence.EF;

namespace Pms.Infrastructure.Persistence.EF.Repositories
{
    public interface IGeneralSqlRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> AllAsync();
        IQueryable<TEntity> AllAsync(int pageSize, int pageNumber);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predict);

    }
}
