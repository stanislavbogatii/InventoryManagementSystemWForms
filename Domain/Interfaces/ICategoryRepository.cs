using Domain.Entitites;

namespace Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdAsync(int id);
        Task AddAsync(Category category);
    }
}
