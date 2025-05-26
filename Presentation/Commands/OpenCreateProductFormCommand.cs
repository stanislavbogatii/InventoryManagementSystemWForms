using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Forms;

public class OpenCreateProductFormCommand : ICommand
{
    private readonly AdminHomeForm _form;
    private readonly IServiceProvider _serviceProvider;

    public OpenCreateProductFormCommand(AdminHomeForm form, IServiceProvider serviceProvider)
    {
        _form = form;
        _serviceProvider = serviceProvider;
    }

    public async void Execute()
    {
        var form = _serviceProvider.GetRequiredService<CreateProductForm>();
        if (form.ShowDialog() == DialogResult.OK)
        {
            await _form.LoadProductsAsync();
        }
    }
}

