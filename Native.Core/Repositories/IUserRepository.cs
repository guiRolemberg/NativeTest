using Native.Core.Entities;
using System.Threading.Tasks;

namespace Native.Core.Repositories;
public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
    Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    Task AddAsync(User user);
}