using Application.Interfaces;
using Domain.Interfaces;
using Presentation.Forms;

namespace Presentation.Commands
{
    internal class LoadProductsCommand : ICommand
    {
        private readonly AdminHomeForm _form;
        private readonly IProductService _productService;

        public LoadProductsCommand(AdminHomeForm form, IProductService productService)
        {
            _form = form;
            _productService = productService;
        }

        public async void Execute()
        {
            await _form.LoadProductsAsync();
        }
    }
}
