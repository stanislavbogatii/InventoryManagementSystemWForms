using Application.Interfaces;
using Domain.Interfaces;
using Presentation.Forms;

public class DeleteProductCommand : ICommand
{
    private readonly AdminHomeForm _form;
    private readonly IProductService _productService;
    private readonly int _productId;
    private readonly int _rowIndex;

    public DeleteProductCommand(AdminHomeForm form, IProductService productService, int productId, int rowIndex)
    {
        _form = form;
        _productService = productService;
        _productId = productId;
        _rowIndex = rowIndex;
    }

    public async void Execute()
    {
        var confirm = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo);
        if (confirm == DialogResult.Yes)
        {
            await _productService.Delete(_productId);
            _form.dgvProducts.Rows.RemoveAt(_rowIndex);
        }
    }
}
