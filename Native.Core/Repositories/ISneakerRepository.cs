using Native.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Native.Core.Repositories
{
    public interface ISneakerRepository
    {
        Task<List<Sneaker>> GetAllAsync(int idUser);
        Task<List<Sneaker>> GetAllSearchAsync(int idUser, string query);
        Task<Sneaker> GetDetailsByIdAsync(int id);
        Task<Sneaker> GetByIdAsync(int id);        
        Task AddAsync(Sneaker sneaker);
        Task DeleteAsync(Sneaker sneaker);
        Task UpdateAsync(Sneaker sneaker);
        Task SaveChangesAsync();
    }
}
