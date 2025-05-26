using Application.DTOs.Product;
using Application.Interfaces;
using Domain.Interfaces;
using Presentation.Forms;

public class GenerateReportCommand : ICommand
{
    private readonly AdminHomeForm _form;
    private readonly IProductService _productService;

    public GenerateReportCommand(AdminHomeForm form, IProductService productService)
    {
        _form = form;
        _productService = productService;
    }

    public async void Execute()
    {
        var products = await _productService.GetAll();
        var selected = _form.comboBoxReportType.SelectedItem?.ToString();

        if (products == null || string.IsNullOrEmpty(selected))
        {
            MessageBox.Show("Please select report type and ensure there are products");
            return;
        }

        var reportFacade = new Application.Facades.ReportFacade();
        var workbook = reportFacade.GenerateExcelReport((List<ProductDto>)products, selected);

        using var saveFileDialog = new SaveFileDialog
        {
            Filter = "Excel Workbook|*.xlsx",
            Title = "Save excel report",
            FileName = $"report_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
        };

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            workbook.SaveAs(saveFileDialog.FileName);
            MessageBox.Show("Report success saved!");
        }
    }
}
