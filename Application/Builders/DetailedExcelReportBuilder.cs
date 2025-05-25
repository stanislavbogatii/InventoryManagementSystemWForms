using Application.DTOs.Product;
using Application.Interfaces;
using ClosedXML.Excel;

namespace Application.Builders;
public class DetailedExcelReportBuilder : IExcelReportBuilder
{
    private XLWorkbook _workbook;
    private IXLWorksheet _worksheet;
    private readonly List<ProductDto> _products;

    public DetailedExcelReportBuilder(List<ProductDto> products)
    {
        _products = products;
        _workbook = new XLWorkbook();
        _worksheet = _workbook.Worksheets.Add("Detailed report");
    }

    public void BuildHeader()
    {
        _worksheet.Cell(1, 1).Value = "Detailed products report";
        _worksheet.Range(1, 1, 1, 5).Merge();
        var headerCell = _worksheet.Cell(1, 1);
        headerCell.Style.Font.Bold = true;
        headerCell.Style.Font.FontSize = 18;
        headerCell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
    }

    public void BuildBody()
    {
        _worksheet.Cell(3, 1).Value = "Title";
        _worksheet.Cell(3, 2).Value = "Price";
        _worksheet.Cell(3, 3).Value = "Quantity";
        _worksheet.Cell(3, 4).Value = "Sum";

        _worksheet.Range(3, 1, 3, 4).Style.Font.Bold = true;
        _worksheet.Range(3, 1, 3, 4).Style.Fill.BackgroundColor = XLColor.LightGray;

        int row = 4;
        foreach (var p in _products)
        {
            _worksheet.Cell(row, 1).Value = p.Title;
            _worksheet.Cell(row, 2).Value = p.Price;
            _worksheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00 MDL";
            _worksheet.Cell(row, 3).Value = p.Quantity;
            _worksheet.Cell(row, 4).FormulaA1 = $"B{row}*C{row}";
            _worksheet.Cell(row, 4).Style.NumberFormat.Format = "#,##0.00 MDL";
            row++;
        }

        _worksheet.Columns(1, 4).AdjustToContents();
    }

    public void BuildFooter()
    {
        int footerRow = _products.Count + 5;
        _worksheet.Cell(footerRow, 3).Value = "Total:";
        _worksheet.Cell(footerRow, 4).FormulaA1 = $"SUM(D4:D{footerRow - 1})";
        _worksheet.Cell(footerRow, 4).Style.Font.Bold = true;
        _worksheet.Cell(footerRow, 4).Style.NumberFormat.Format = "#,##0.00 MDL";
    }

    public XLWorkbook GetReport()
    {
        return _workbook;
    }
}
