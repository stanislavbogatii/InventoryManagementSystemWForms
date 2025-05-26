using Domain.Entitites;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task CreateAsync(User user);

        Task UpdateAsync(User user);

        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);

        Task DeleteAsync(int id);

        Task<bool>  AnyExistsAsync();
    }
}
