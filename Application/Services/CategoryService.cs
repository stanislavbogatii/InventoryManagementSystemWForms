using Application.DTOs.Category;
using Application.Interfaces;
using Domain.Entitites;
using Domain.Interfaces;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Create(CreateCategoryDto dto)
        {
            Category newCategory = new()
            {
                Title = dto.Title,
                CategoryCode = dto.CategoryCode,
                ParentId = dto.ParentId,
            };
            await _categoryRepository.AddAsync(newCategory);
        }

        public async Task Delete(int id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();
            if (categories is not null)
            {
                return categories.Select(c => ToDto(c)).ToList();
            }
            return [];
        }

        public async Task<CategoryDto?> GetById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return ToDto(category);
        }

        public async Task Update(int id, UpdateCategoryDto dto)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) throw new Exception("Category not found");
            category.Title = dto.Title;
            category.CategoryCode = dto.CategoryCode;
            category.ParentId = dto.ParentId;

            await _categoryRepository.UpdateAsync(category);
        }

        private CategoryDto ToDto(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Title= category.Title,
                CategoryCode= category.CategoryCode,
                ParentId= category.ParentId,
                Categories = category?.Categories ?? [],
                Parent = category.Parent,
            };
        }
    }
}
