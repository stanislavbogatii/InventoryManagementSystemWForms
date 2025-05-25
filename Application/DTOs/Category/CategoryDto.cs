
namespace Application.DTOs.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string CategoryCode { get; set; } = string.Empty;

        public int? ParentId { get; set; } = null;

        public Domain.Entitites.Category? Parent { get; set; } = null;

        public ICollection<Domain.Entitites.Category?> Categories { get; set; } = new List<Domain.Entitites.Category?>();

        public ICollection<Domain.Entitites.Product> Products { get; set; } = new List<Domain.Entitites.Product>();
    }
}
