using Domain.Entitites;

namespace Domain.Interfaces
{
    public interface IWarehouseRepository
    {
        Task<IEnumerable<Warehouse>> GetAllAsync();
        Task<Warehouse?> GetByIdAsync(int id);
        Task AddAsync(Warehouse location);
        Task UpdateAsync(Warehouse location);
        Task DeleteAsync(int id);
    }
}
