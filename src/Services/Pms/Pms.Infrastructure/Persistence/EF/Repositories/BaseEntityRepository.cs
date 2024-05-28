using System.Linq.Expressions;
using Core.EventBus.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pms.Domain.Repositories;
using Pms.Infrastructure.Persistence.EF.DbContexts;
using SharedKernel.Common.SqlModels;

namespace Pms.Infrastructure.Persistence.EF.Repositories;

public class BaseEntityRepository<TEntity> : IGeneralSqlRepository<TEntity> where TEntity : BaseEntity
{
    private readonly PaymentDbContext _paymentDbContext;
    private readonly IDomainEventHandlingExecutor _domainEventHandlingExecutor;
    private DbSet<TEntity> _dbSet;
    public BaseEntityRepository(PaymentDbContext paymentDbContext, IDomainEventHandlingExecutor domainEventHandlingExecutor)
    {
        _paymentDbContext = paymentDbContext;
        _domainEventHandlingExecutor = domainEventHandlingExecutor;
        _dbSet = paymentDbContext.Set<TEntity>();
    }


    public IQueryable<TEntity> AllAsync()
    {
        return _dbSet.AsQueryable();
    }

    public IQueryable<TEntity> AllAsync(int pageSize, int pageNumber)
    {
        var number = (pageNumber - 1) * pageSize;

        return _dbSet.AsQueryable().Skip(number).Take(pageSize);
    }

    public Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predict)
    {
        return _dbSet.Where(predict).ToListAsync();
    }

    public Task<TEntity?> GetAsync(Guid uxId)
    {
        return _dbSet.SingleOrDefaultAsync(q => q.UxId == uxId);
    }

    public Task InsertAsync(TEntity entity)
    {
        _dbSet.AddAsync(entity);

        SaveChangesAsync();

        return Task.CompletedTask;
    }

    public Task UpdateAsync(TEntity entity)
    {
        _dbSet.Entry(entity).State = EntityState.Modified;

        SaveChangesAsync();

        return Task.CompletedTask;
    }

    private Task<int> SaveChangesAsync()
    {
        var numberOfChanges = _paymentDbContext.SaveChangesAsync();

        var events = GetDomainEventEntities(_paymentDbContext.ChangeTracker);

        _domainEventHandlingExecutor.SaveEventAsync(events);

        return numberOfChanges;
    }

    private static List<DomainEvent> GetDomainEventEntities(ChangeTracker changeTracker)
    {
        return changeTracker.Entries<BaseEntity>()
            .Select(po => po.Entity)
            .Where(po => po.Events.Any())
            .SelectMany(q => q.Events)
            .ToList();
    }
}