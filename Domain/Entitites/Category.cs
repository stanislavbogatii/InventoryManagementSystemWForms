namespace Domain.Entitites
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string CategoryCode { get; set; }

        public int? ParentId { get; set; } = null;

        public Category? Parent { get; set; } = null;

        public ICollection<Category> Categories { get; set; } = new List<Category>();

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
