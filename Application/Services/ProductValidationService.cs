using Application.DTOs.Product;
using Application.Handlers;

namespace Application.Services;
public class ProductValidationService
{
    private readonly ProductValidatorHandler _validatorChain;

    public ProductValidationService()
    {
        var nameValidator = new NameValidator();
        var priceValidator = new PriceValidator();

        nameValidator.SetNext(priceValidator);

        _validatorChain = nameValidator;
    }

    public bool Validate(CreateProductDto product, out string errorMessage)
    {
        return _validatorChain.Handle(product, out errorMessage);
    }
}
