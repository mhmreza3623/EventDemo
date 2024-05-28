using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Persistence.DbContexts;

public class AppIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
{
    public DbSet<Client> Clients { get; set; }

    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }

}