namespace Application.DTOs.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Article { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; } = 0;
        public int OldPrice { get; set; } = 0;
        public int Quantity { get; set; } = 0;

        public int? CategoryId { get; set; } = null;
        public string CategoryTitle { get; set; } = string.Empty;
    }
}
