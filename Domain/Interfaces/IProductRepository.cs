using Domain.Entitites;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task DeleteAsync(int id);

        Task<IEnumerable<Product>> GetAllAsync();
    }
}
