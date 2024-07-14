using Native.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Native.Infrastructure.Persistence;
public class NativeDbContext(DbContextOptions<NativeDbContext> options) : DbContext(options)
{
    public DbSet<Sneaker> Sneakers { get; set; }
    public DbSet<User> Users { get; set; }    
    public DbSet<UserSneaker> UserSneakers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
