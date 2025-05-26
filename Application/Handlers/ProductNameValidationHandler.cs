using Application.DTOs.Product;
using Application.Handlers;

namespace Application.Handlers;
public class NameValidator : ProductValidatorHandler
{
    public override bool Handle(CreateProductDto product, out string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(product.Title))
        {
            errorMessage = "Product name cannot be empty.";
            return false;
        }
        if (Next != null)
            return Next.Handle(product, out errorMessage);

        errorMessage = string.Empty;
        return true;
    }
}
