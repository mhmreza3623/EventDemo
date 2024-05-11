using DataBase.Core;
using System.Linq.Expressions;
using Azure.Core;
using System;

namespace Pms.Infrastructure.Persistence.MongoDb.Repositories
{
    public interface IGeneralMongoRepository<TEntity>
        where TEntity : BaseCollection
    {
        Task<bool> InsertAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<IList<TEntity>> SearchFor(Expression<Func<TEntity, bool>> predicate);
        Task<IList<TEntity>> GetAll();
        TEntity GetById(Guid id);
    }
}
