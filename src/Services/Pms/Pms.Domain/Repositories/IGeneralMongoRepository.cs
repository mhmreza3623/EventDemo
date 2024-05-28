using SharedKernel.Common.MongoDb;

namespace Pms.Domain.Repositories
{
    public interface IGeneralMongoRepository<TEntity>
        where TEntity : MongoBaseEntity
    {
        Task<bool> InsertAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<IList<TEntity>> SearchFor(Predicate<TEntity> predicate);
        Task<IList<TEntity>> GetAll();
        TEntity? GetById(string id);
    }
}
