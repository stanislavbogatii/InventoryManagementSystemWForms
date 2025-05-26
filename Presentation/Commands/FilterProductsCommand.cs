using Domain.Interfaces;
using Presentation.Forms;

public class FilterProductsCommand : ICommand
{
    private readonly AdminHomeForm _form;

    public FilterProductsCommand(AdminHomeForm form)
    {
        _form = form;
    }

    public void Execute()
    {
        _form.FilterProducts();
    }
}
