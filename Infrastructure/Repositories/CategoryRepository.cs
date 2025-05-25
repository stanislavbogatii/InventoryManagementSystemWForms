using Domain.Entitites;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        AppDbContext _context;
        public CategoryRepository(AppDbContext context) 
        {
            _context = context;
        }
        public async Task AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories
            .Include(c => c.Parent)
            .Select(c => new Category
            {
                Id = c.Id,
                Title = c.Title,
                CategoryCode = c.CategoryCode,
                Parent = c.Parent,
                ParentId = c.ParentId,
                Products = c.Products
            })
            .ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await GetByIdAsync(id);
            if (category is not null)
            {
                _context.Categories.Remove(category);
            }
            await _context.SaveChangesAsync();
        }
    }
}
