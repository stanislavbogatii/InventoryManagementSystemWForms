using Domain.Entitites;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-BJHK5QL;Database=InnventoryDB;Trusted_Connection=True;TrustServerCertificate=True"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.Role).IsRequired();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Title).IsRequired().HasMaxLength(100);
                entity.Property(c => c.CategoryCode).IsRequired();
                
                entity.HasOne(c => c.Parent)
                    .WithMany(c => c.Categories)
                    .HasForeignKey(c => c.ParentId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Code).IsRequired();
                entity.Property(e => e.Article).IsRequired();
                entity.Property(e => e.Description).HasDefaultValue(string.Empty);

                entity.HasOne(p => p.Category)
                    .WithMany()
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(p => p.WarehouseLocation)
                      .WithMany(w => w.Products)
                      .HasForeignKey(p => p.WarehouseLocationId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.StorageType).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Length).IsRequired();
                entity.Property(e => e.Width).IsRequired();
                entity.Property(e => e.Height).IsRequired();
                entity.Property(e => e.MaxLoadCapacity).IsRequired();
                entity.Property(e => e.AccessLevel).IsRequired().HasMaxLength(100);
                entity.Property(e => e.HasSecuritySystem).IsRequired();
                entity.Property(w => w.AccessLevel)
                  .HasConversion<string>()
                  .IsRequired();
                entity.Property(w => w.StorageType)
                  .HasConversion<string>()
                  .IsRequired();
            });

        }
    }
}
