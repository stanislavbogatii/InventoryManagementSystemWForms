namespace Domain.Filters
{
    public class ProductFilters
    {
        public int? minPrice { get; set; } = null;
        public int? maxPrice { get; set;} = null;
        public string? title { get; set; } = null;
    }
}
