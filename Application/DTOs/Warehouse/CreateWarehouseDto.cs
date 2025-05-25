namespace Application.DTOs.Warehouse
{
    public class WarehouseDto
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
    }

}
