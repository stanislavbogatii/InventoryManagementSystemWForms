using Application.DTOs.Category;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<CategoryDto?> GetById(int id);
        public Task<IEnumerable<CategoryDto>> GetAll();
        public Task Create(CreateCategoryDto dto);
        public Task Update(int id, UpdateCategoryDto dto);
        public Task Delete(int id);
    }
}
