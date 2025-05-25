using Application.DTOs.Warehouse;

public interface IWarehouseService
{
    Task<IEnumerable<WarehouseDto>> GetAllAsync();
    Task<WarehouseDto?> GetByIdAsync(int id);
    Task CreateAsync(CreateWarehouseDto dto);
    Task UpdateAsync(int id, CreateWarehouseDto dto); 
    Task DeleteAsync(int id);
}
