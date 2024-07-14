using Native.Core.Entities;
using Native.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Native.Infrastructure.Persistence.Repositories;
public class SneakerRepository(NativeDbContext dbContext) : ISneakerRepository
{
    private readonly NativeDbContext _dbContext = dbContext;

    public async Task<List<Sneaker>> GetAllAsync(int idUser)
    {
        return await _dbContext.Sneakers.Where(x => x.IdUser == idUser).ToListAsync();
    }

    public async Task<List<Sneaker>> GetAllSearchAsync(int idUser, string query)
    {
        return await _dbContext.Sneakers.Where(x => x.IdUser == idUser).ToListAsync();
    }

    public async Task<Sneaker> GetDetailsByIdAsync(int id)
    {
        return await _dbContext.Sneakers
            .Include(p => p.User)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Sneaker> GetByIdAsync(int id)
    {
        return await _dbContext.Sneakers.SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Sneaker sneaker)
    {
        await _dbContext.Sneakers.AddAsync(sneaker);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Sneaker sneaker)
    {
        _dbContext.Sneakers.Remove(sneaker);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Sneaker sneaker)
    {
        _dbContext.Sneakers.Update(sneaker);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }


}