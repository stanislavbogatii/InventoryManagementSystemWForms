namespace Application.DTOs.Warehouse
{
    public class WarehouseDto : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StorageType { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double MaxLoadCapacity { get; set; }
        public string AccessLevel { get; set; }
        public bool HasSecuritySystem { get; set; }
        public List<int> ProductIds { get; set; }

        public object Clone()
        {
            return new WarehouseDto
            {
                Name = this.Name,
                Length = this.Length,
                Width = this.Width,
                Height = this.Height,
                MaxLoadCapacity = this.MaxLoadCapacity,
                StorageType = this.StorageType,
                AccessLevel = this.AccessLevel,
                HasSecuritySystem = this.HasSecuritySystem
            };
        }
    }
}
