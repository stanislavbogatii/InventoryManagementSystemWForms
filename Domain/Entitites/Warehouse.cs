using Domain.Enums;

namespace Domain.Entitites
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public WarehouseStorageTypeEnum StorageType { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double MaxLoadCapacity { get; set; }
        public WarehouseAccessLevelEnum AccessLevel { get; set; } = 0;
        public bool HasSecuritySystem { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

        public Warehouse Clone()
        {
            return new Warehouse
            {
                Name = this.Name + " (копия)",
                StorageType = this.StorageType,
                Length = this.Length,
                Width = this.Width,
                Height = this.Height,
                MaxLoadCapacity = this.MaxLoadCapacity,
                AccessLevel = this.AccessLevel,
                HasSecuritySystem = this.HasSecuritySystem
            };
        }
    }

}
