using System.Linq.Expressions;
using Pms.Application.Queries;
using Pms.Domain.Entities;
using Pms.Domain.Repositories;

namespace Pms.Infrastructure.Persistence.EF.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly IGeneralSqlRepository<Client> _clientRepository;

    public ClientRepository(IGeneralSqlRepository<Client> clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<IQueryable<Client>> GetAllAsync()
    {
        return _clientRepository.AllAsync();
    }

    public Task<Client?> GetAsync(Guid uxId)
    {
        return _clientRepository.GetAsync(uxId);
    }

    public Task<List<Client>> GetAsync(Expression<Func<Client, bool>> predict)
    {
        return _clientRepository.GetAsync(predict);
    }

    public Task UpdateAsync(Client client)
    {
        _clientRepository.UpdateAsync(client);
        
        return Task.CompletedTask;
    }
}