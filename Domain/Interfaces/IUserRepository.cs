using Domain.Entitites;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task CreateAsync(User user);

        Task UpdateAsync(User user);
    }
}
