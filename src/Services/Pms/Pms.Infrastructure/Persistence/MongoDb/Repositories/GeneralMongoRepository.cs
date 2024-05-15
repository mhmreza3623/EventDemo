using System;
using System.Collections.Immutable;
using System.Linq.Expressions;
using DataModels.Core.MongoDb;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pms.Domain.Repositories;

namespace Pms.Infrastructure.Persistence.MongoDb.Repositories;

public class GeneralMongoRepository<TEntity> : IGeneralMongoRepository<TEntity>
    where TEntity : MongoBaseEntity
{
    private readonly IMongoCollection<TEntity> _paymentCollection;

    public GeneralMongoRepository(IOptions<MongodbConfig> paymentDatabase)
    {
        var mongoClient = new MongoClient(paymentDatabase.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(paymentDatabase.Value.DatabaseName);
        _paymentCollection = mongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name);
    }

    public async Task<bool> InsertAsync(TEntity entity)
    {
        await _paymentCollection.InsertOneAsync(entity);
        return true;
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        await _paymentCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        return true;
    }

    public async Task<bool> Delete(TEntity entity)
    {
        await _paymentCollection.DeleteOneAsync(x => x.Id == entity.Id);
        return true;
    }

    public async Task<IList<TEntity>> SearchFor(Predicate<TEntity> predicate)
    {
        var isDeletedFilter = Builders<TEntity>.Filter.Where(p => !p.IsDeleted);
        var filter = Builders<TEntity>.Filter.And(isDeletedFilter);
        var availableData = _paymentCollection.Find(filter).ToList();
        return availableData.FindAll(predicate).ToList();
    }

    public async Task<IList<TEntity>> GetAll()
    {
        var isDeletedFilter = Builders<TEntity>.Filter.Where(p => !p.IsDeleted);
        var filter = Builders<TEntity>.Filter.And(isDeletedFilter);
        var availableData = _paymentCollection.Find(filter).ToList();

        return availableData.ToImmutableList();
    }

    public TEntity? GetById(string id)
    {
        var isDeletedFilter = Builders<TEntity>.Filter.Where(p => !p.IsDeleted);
        var filter = Builders<TEntity>.Filter.And(isDeletedFilter);
        var availableData = _paymentCollection.Find(filter).ToList();

        return availableData.Find(q => q.Id == id);
    }
}