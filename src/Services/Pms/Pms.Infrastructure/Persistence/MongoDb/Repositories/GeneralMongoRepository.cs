using System.Linq.Expressions;
using DataBase.Core;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Pms.Infrastructure.Persistence.MongoDb.Repositories;

public class GeneralMongoRepository<TEntity> : IGeneralMongoRepository<TEntity> where TEntity : BaseCollection
{
    private readonly IMongoCollection<TEntity> _booksCollection;

    public GeneralMongoRepository(IOptions<MongodbConfig> paymentDatabase)
    {
        var mongoClient = new MongoClient(paymentDatabase.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(paymentDatabase.Value.DatabaseName);
        _booksCollection = mongoDatabase.GetCollection<TEntity>(paymentDatabase.Value.BooksCollectionName);
    }

    public async Task<bool> InsertAsync(TEntity entity)
    {
        await _booksCollection.InsertOneAsync(entity);
        return true;
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        await _booksCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        return true;
    }

    public async Task<bool> Delete(TEntity entity)
    {
        await _booksCollection.DeleteOneAsync(x => x.Id == entity.Id);
        return true;
    }

    public async Task<IList<TEntity>> SearchFor(Expression<Func<TEntity, bool>> predicate)
    {
        return await _booksCollection.Find(predicate).ToListAsync();
    }

    public async Task<IList<TEntity>> GetAll()
    {
        return await _booksCollection.FindAsync();
    }

    public TEntity GetById(Guid id)
    {
        return await _booksCollection.Find(q=>q.Id==id);
    }
}