namespace Infrastructure.Repositories
{
    using Domain.Entitites;
    using Domain.Interfaces;
    using Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;

    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly AppDbContext _context;

        public WarehouseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            return await _context.Warehouses.Include(w => w.Products).ToListAsync();
        }

        public async Task<Warehouse?> GetByIdAsync(int id)
        {
            return await _context.Warehouses
                                 .Include(w => w.Products)
                                 .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task AddAsync(Warehouse location)
        {
            _context.Warehouses.Add(location);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Warehouse location)
        {
            _context.Warehouses.Update(location);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var location = await _context.Warehouses.FindAsync(id);
            if (location != null)
            {
                _context.Warehouses.Remove(location);
                await _context.SaveChangesAsync();
            }
        }
    }

}
