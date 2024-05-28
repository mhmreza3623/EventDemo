using System.Linq.Expressions;
using System.Runtime.InteropServices.JavaScript;
using Pms.Application.Queries;
using Microsoft.AspNetCore.Identity;
using Pms.Domain.Entities;
using Pms.Infrastructure.Persistence.EF.DbContexts;

namespace Pms.Infrastructure.Persistence.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PaymentDbContext _dbContexts;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;


        public UserRepository(PaymentDbContext dbContexts,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _dbContexts = dbContexts;
            _signInManager = signInManager;
            _userManager = userManager;

        }

        public async Task<ApplicationUser?> GetUserByPassword(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            var isValidUserPassword = await _signInManager.UserManager.CheckPasswordAsync(user, password);

            return isValidUserPassword ? user : null;
        }

        public IQueryable<ApplicationUser> GetUsers(Expression<Func<ApplicationUser, bool>> predict)
        {
            return _dbContexts.Users.Where(predict);
        }
    }
}
