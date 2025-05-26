using Domain.Entitites;

public class ProductMemento
{
    public int Id { get; }
    public string Title { get; }
    public string Code { get; }
    public string Article { get; }
    public string Description { get; }
    public int Quantity { get; }
    public int Price { get; }
    public int OldPrice { get; }
    public int? CategoryId { get; }
    public int? WarehouseId { get; }

    public ProductMemento(Product product)
    {
        Id = product.Id;
        Title = product.Title ?? string.Empty;
        Code = product.Code ?? string.Empty;
        Article = product.Article ?? string.Empty;
        Description = product.Description ?? string.Empty;
        Quantity = product.Quantity;
        Price = product.Price;
        OldPrice = product.OldPrice;
        CategoryId = product.CategoryId;
        WarehouseId = product.WarehouseId;
    }
}
