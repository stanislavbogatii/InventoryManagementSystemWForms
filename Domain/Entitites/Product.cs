namespace Domain.Entitites
{
    public class Product
    {
        public int Id { get; set; }
        
        public string? Title { get; set; }
        
        public string? Code { get; set; }

        public string? Article { get; set; }

        public int Quantity { get; set; } = 0;

        public int Price { get; set; } = 0;

        public int OldPrice { get; set; } = 0;

        public string Description { get; set; } = string.Empty;

        public int? CategoryId { get; set; } = null; 

        public Category Category { get; set; } = null!;
    }
}
