using Application.DTOs.Product;

namespace Application.Handlers;
public abstract class ProductValidatorHandler
{
    protected ProductValidatorHandler? Next { get; private set; }

    public void SetNext(ProductValidatorHandler next)
    {
        Next = next;
    }

    public abstract bool Handle(CreateProductDto product, out string errorMessage);
}
