using Application.DTOs.Product;
using Domain.Filters;

namespace Application.Interfaces
{
    public interface IProductService
    {
        public Task<ProductDto?> GetById(int id);
        public Task<ProductDto?> GetByUsername(string username);
        public Task<IEnumerable<ProductDto>> GetAll(ProductFilters? filters = null);
        public Task Create(CreateProductDto dto);
        public Task Update(int id);
        public Task Delete(int id);
    }
}
