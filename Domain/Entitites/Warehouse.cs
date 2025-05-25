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
    }

}
