using Application.DTOs.Product;
using Application.Interfaces;
using Domain.Entitites;
using Domain.Filters;
using Domain.Interfaces;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepo;
        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;

        }
        public async Task Create(CreateProductDto dto)
        {
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

        public Task<ProductDto?> GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id)
        {
            throw new NotImplementedException();
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
                OldPrice = product.OldPrice,
                Quantity = product.Quantity,
                CategoryId = product.CategoryId,
                CategoryTitle = product.Category?.Title ?? string.Empty
            };
        }
    }
}
