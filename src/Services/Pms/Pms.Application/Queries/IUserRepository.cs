using System.Linq.Expressions;
using Pms.Domain.Entities;

namespace Pms.Application.Queries
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> GetUserByPassword(string username, string password);
        IQueryable<ApplicationUser> GetUsers(Expression<Func<ApplicationUser, bool>> predict);

    }
}
