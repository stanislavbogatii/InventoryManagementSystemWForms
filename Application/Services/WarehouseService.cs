using Domain.Entitites;
using Application.DTOs.Warehouse;
using Domain.Interfaces;
using Domain.Enums;

public class WarehouseService : IWarehouseService
{
    private readonly IWarehouseRepository _repository;

    public WarehouseService(IWarehouseRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<WarehouseDto>> GetAll()
    {
        var locations = await _repository.GetAllAsync();
        return locations.Select(l => MapToDto(l)).ToList();
    }

    public async Task<WarehouseDto?> GetById(int id)
    {
        var location = await _repository.GetByIdAsync(id);
        return location == null ? null : MapToDto(location);
    }

    public async Task Create(CreateWarehouseDto dto)
    {
        var warehouse = new Warehouse
        {
            Name = dto.Name,
            StorageType = Enum.Parse<WarehouseStorageTypeEnum>(dto.StorageType),
            Length = dto.Length,
            Width = dto.Width,
            Height = dto.Height,
            MaxLoadCapacity = dto.MaxLoadCapacity,
            AccessLevel = Enum.Parse<WarehouseAccessLevelEnum>(dto.AccessLevel),
            HasSecuritySystem = dto.HasSecuritySystem,
        };

        await _repository.AddAsync(warehouse);
    }

    public async Task Update(int id, UpdateWarehouseDto dto)
    {
        var warehouse = await _repository.GetByIdAsync(id);
        if (warehouse == null) throw new Exception("Warehouse not found");

        warehouse.Name = dto.Name;
        warehouse.StorageType = Enum.Parse<WarehouseStorageTypeEnum>(dto.StorageType);
        warehouse.Length = dto.Length;
        warehouse.Width = dto.Width;
        warehouse.Height = dto.Height;
        warehouse.MaxLoadCapacity = dto.MaxLoadCapacity;
        warehouse.AccessLevel = Enum.Parse<WarehouseAccessLevelEnum>(dto.AccessLevel);
        warehouse.HasSecuritySystem = dto.HasSecuritySystem;

        await _repository.UpdateAsync(warehouse);
    }

    public async Task Delete(int id)
    {
        await _repository.DeleteAsync(id);
    }

    private WarehouseDto MapToDto(Warehouse location)
    {
        return new WarehouseDto
        {
            Id = location.Id,
            Name = location.Name,
            StorageType = location.StorageType.ToString(),
            Length = location.Length,
            Width = location.Width,
            Height = location.Height,
            MaxLoadCapacity = location.MaxLoadCapacity,
            AccessLevel = location.AccessLevel.ToString(),
            HasSecuritySystem = location.HasSecuritySystem,
            ProductIds = location.Products.Select(p => p.Id).ToList()
        };
    }
}
