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

    public async Task<IEnumerable<WarehouseDto>> GetAllAsync()
    {
        var locations = await _repository.GetAllAsync();
        return locations.Select(l => MapToDto(l)).ToList();
    }

    public async Task<WarehouseDto?> GetByIdAsync(int id)
    {
        var location = await _repository.GetByIdAsync(id);
        return location == null ? null : MapToDto(location);
    }

    public async Task CreateAsync(CreateWarehouseDto dto)
    {
        var location = new Warehouse
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

        await _repository.AddAsync(location);
    }

    public async Task UpdateAsync(int id, CreateWarehouseDto dto)
    {
        var location = await _repository.GetByIdAsync(id);
        if (location == null) throw new Exception("Warehouse not found");

        location.Name = dto.Name;
        location.StorageType = Enum.Parse<WarehouseStorageTypeEnum>(dto.StorageType);
        location.Length = dto.Length;
        location.Width = dto.Width;
        location.Height = dto.Height;
        location.MaxLoadCapacity = dto.MaxLoadCapacity;
        location.AccessLevel = Enum.Parse<WarehouseAccessLevelEnum>(dto.AccessLevel);
        location.HasSecuritySystem = dto.HasSecuritySystem;

        await _repository.UpdateAsync(location);
    }

    public async Task DeleteAsync(int id)
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
