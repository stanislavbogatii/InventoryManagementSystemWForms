using Application.DTOs.Product;
using Application.Handlers;

namespace Application.Handlers;
public class PriceValidator : ProductValidatorHandler
{
    public override bool Handle(CreateProductDto product, out string errorMessage)
    {
        if (product.Price <= 0)
        {
            errorMessage = "Product price must be positive.";
            return false;
        }
        if (product.Price > product.OldPrice && product.OldPrice > 0)
        {
            errorMessage = "Old price must be less than or equal to the current price.";
            return false;
        }
        if (Next != null)
            return Next.Handle(product, out errorMessage);

        errorMessage = string.Empty;
        return true;
    }
}