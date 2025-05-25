using Domain.Interfaces;
using Infrastructure.Data;
using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Domain.Filters;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Warehouse)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product is not null)
            {
                _context.Products.Remove(product);
            }
            await _context.SaveChangesAsync();
        }

        public async Task UdpateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync(ProductFilters? filters = null)
        {
            IQueryable<Product> query = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Warehouse);
            if (filters is not null)
            {
                if (!string.IsNullOrWhiteSpace(filters.title))
                {
                    query = query.Where(p =>
                        (!string.IsNullOrEmpty(p.Title) && p.Title.Contains(filters.title)) ||
                        (!string.IsNullOrEmpty(p.Article) && p.Article.Contains(filters.title)) ||
                        (!string.IsNullOrEmpty(p.Code) && p.Code.Contains(filters.title))
                    );

                }

                if (filters.minPrice.HasValue)
                {
                    query = query.Where(p => p.Price >= filters.minPrice.Value);
                }

                if (filters.maxPrice.HasValue)
                {
                    query = query.Where(p => p.Price <= filters.maxPrice.Value);
                }
            }


            return await query.ToListAsync();
        }

    }
}
