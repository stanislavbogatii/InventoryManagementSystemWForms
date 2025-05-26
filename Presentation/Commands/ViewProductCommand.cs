using Application.Interfaces;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Forms;

public class ViewProductCommand : ICommand
{
    private readonly AdminHomeForm _form;
    private readonly IServiceProvider _serviceProvider;
    private readonly IProductService _productService;
    private readonly int _productId;

    public ViewProductCommand(AdminHomeForm form, IServiceProvider serviceProvider, IProductService productService, int productId)
    {
        _form = form;
        _serviceProvider = serviceProvider;
        _productService = productService;
        _productId = productId;
    }

    public async void Execute()
    {

        var product = await _productService.GetById(_productId);
        if (product == null)
        {
            MessageBox.Show("Product not found!");
            return;
        }

        var editForm = ActivatorUtilities.CreateInstance<ViewProductForm>(_serviceProvider, product);
        if (editForm.ShowDialog() == DialogResult.OK)
        {
            await _form.LoadProductsAsync();
        }
    }
}
