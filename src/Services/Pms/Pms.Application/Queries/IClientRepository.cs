using System.Linq.Expressions;
using Pms.Domain.Entities;

namespace Pms.Application.Queries
{
    public interface IClientRepository
    {
        Task<IQueryable<Client>> GetAllAsync();
        Task<Client> GetAsync(Guid uxId);
        Task<List<Client>> GetAsync(Expression<Func<Client, bool>> predict);
        Task UpdateAsync(Client client);
    }
}
