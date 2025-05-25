namespace Application.DTOs.Category
{
    public class CreateCategoryDto
    {
        public string Title { get; set; } = string.Empty;

        public string CategoryCode { get; set; } = string.Empty;

        public int? ParentId { get; set; } = null;
    }
}

