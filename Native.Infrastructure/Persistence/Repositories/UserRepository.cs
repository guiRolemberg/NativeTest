using Native.Core.Entities;
using Native.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Native.Infrastructure.Persistence.Repositories;
public class UserRepository(NativeDbContext dbContext) : IUserRepository
{
    private readonly NativeDbContext _dbContext = dbContext;

    public async Task AddAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
    {
        return await _dbContext
            .Users
            .SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
    }
}