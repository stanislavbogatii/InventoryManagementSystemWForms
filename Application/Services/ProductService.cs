using Application.DTOs.Product;
using Application.Interfaces;
using Domain.Entitites;
using Domain.Filters;
using Domain.Interfaces;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly ProductValidationService _validationService;
        private readonly ProductMementoRepository _mementoRepository;
        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
            _validationService = new ProductValidationService();
            _mementoRepository = new ProductMementoRepository();
        }
        public async Task Create(CreateProductDto dto)
        {
            if (!_validationService.Validate(dto, out var errorMessage))
            {
                throw new ArgumentException($"Validation failed: {errorMessage}");
            }

            Product product = new()
            {
                Title = dto.Title,
                Price = dto.Price,
                Code = dto.Code,
                Article = dto.Article,
                Quantity = dto.Quantity,
                OldPrice = dto.OldPrice,
                CategoryId = dto.CategoryId,
                Description = dto.Description,
                WarehouseId = dto.WarehouseId,
            };
            await _productRepo.AddAsync(product);
        }

        public async Task Delete(int id)
        {
            await _productRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductDto>> GetAll(ProductFilters? filters = null)
        {
            var products = await _productRepo.GetAllAsync(filters);
            if (products is not null)
            {
                return products.Select(p => ToDto(p)).ToList();
            }
            return [];
        }

        public async Task<ProductDto?> GetById(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product is not null)
            {
                return ToDto(product);
            }
            return null;
        }

        public async Task Update(int id, UpdateProductDto dto)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null) throw new Exception("Product not found");
                
            _mementoRepository.SaveMemento(product);

            product.Title = dto.Title;
            product.Price = dto.Price;
            product.Code = dto.Code;
            product.Article = dto.Article;
            product.Quantity = dto.Quantity;
            product.OldPrice = dto.OldPrice;
            product.WarehouseId = dto.WarehouseId;
            product.CategoryId = dto.CategoryId;
            product.Description = dto.Description;

            await _productRepo.UdpateAsync(product);
        }

        public async Task RestoreFromMemento(int id)
        {
            var memento = _mementoRepository.GetMemento(id);
            if (memento == null) throw new Exception("No previous version to restore");

            var product = await _productRepo.GetByIdAsync(id);
            if (product == null) throw new Exception("Product not found");

            product.Title = memento.Title;
            product.Code = memento.Code;
            product.Article = memento.Article;
            product.Description = memento.Description;
            product.Quantity = memento.Quantity;
            product.Price = memento.Price;
            product.OldPrice = memento.OldPrice;
            product.WarehouseId = memento.WarehouseId;
            product.CategoryId = memento.CategoryId;

            await _productRepo.UdpateAsync(product);

            _mementoRepository.RemoveMemento(id);
        }

        public bool HasMemento(int id)
        {
            return _mementoRepository.HasMemento(id);
        }

        public static ProductDto ToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Title = product.Title ?? string.Empty,
                Code = product.Code ?? string.Empty,
                Article = product.Article ?? string.Empty,
                Description = product.Description ?? string.Empty,
                Price = product.Price,
                WarehouseId = product.WarehouseId,
                Warehouse = product.Warehouse,
                OldPrice = product.OldPrice,
                Quantity = product.Quantity,
                CategoryId = product.CategoryId,
                CategoryTitle = product.Category?.Title ?? string.Empty,
                WarehouseName = product.Warehouse?.Name ?? string.Empty,
            };
        }
    }
}
