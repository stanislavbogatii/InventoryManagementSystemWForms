using Application.DTOs.Warehouse;

public interface IWarehouseService
{
    Task<IEnumerable<WarehouseDto>> GetAll();
    Task<WarehouseDto?> GetById(int id);
    Task Create(CreateWarehouseDto dto);
    Task Update(int id, UpdateWarehouseDto dto); 
    Task Delete(int id);
}
