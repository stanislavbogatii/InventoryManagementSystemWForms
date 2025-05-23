using Domain.Entitites;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        User? GetByUsername(string username);
        void Add(User user);
    }
}
