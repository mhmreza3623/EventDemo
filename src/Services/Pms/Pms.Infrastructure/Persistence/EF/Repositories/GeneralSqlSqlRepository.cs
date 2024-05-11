using System.Linq.Expressions;
using DataBase.Core;
using Microsoft.EntityFrameworkCore;

namespace Pms.Infrastructure.Persistence.EF.Repositories;

public class GeneralSqlSqlRepository<TEntity> : IGeneralSqlRepository<TEntity> where TEntity : BaseEntity
{
    private DbSet<TEntity> _dbSet;
    public GeneralSqlSqlRepository(PaymentDbContext paymentDbContext)
    {
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
}