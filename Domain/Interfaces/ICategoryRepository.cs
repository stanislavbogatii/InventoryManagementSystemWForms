using Domain.Entitites;

namespace Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdAsync(int id);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
