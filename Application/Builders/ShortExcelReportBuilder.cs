using Application.DTOs.Product;
using Application.Interfaces;
using ClosedXML.Excel;

namespace Application.Builders;
public class ShortExcelReportBuilder : IExcelReportBuilder
{
    private XLWorkbook _workbook;
    private IXLWorksheet _worksheet;
    private readonly List<ProductDto> _products;

    public ShortExcelReportBuilder(List<ProductDto> products)
    {
        _products = products;
        _workbook = new XLWorkbook();
        _worksheet = _workbook.Worksheets.Add("Report");
    }

    public void BuildHeader()
    {
        _worksheet.Cell(1, 1).Value = "Short products report";
        var headerCell = _worksheet.Cell(1, 1);
        headerCell.Style.Font.Bold = true;
        headerCell.Style.Font.FontSize = 16;
        _worksheet.Range(1, 1, 1, 3).Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
    }

    public void BuildBody()
    {
        _worksheet.Cell(3, 1).Value = "Title";
        _worksheet.Cell(3, 2).Value = "Price";

        _worksheet.Range(3, 1, 3, 2).Style.Font.Bold = true;
        _worksheet.Range(3, 1, 3, 2).Style.Fill.BackgroundColor = XLColor.LightGray;

        int row = 4;
        foreach (var p in _products)
        {
            _worksheet.Cell(row, 1).Value = p.Title;
            _worksheet.Cell(row, 2).Value = p.Price;
            _worksheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00 MDL";
            row++;
        }

        _worksheet.Columns(1, 2).AdjustToContents();
    }

    public void BuildFooter()
    {
        int totalItems = _products.Count;
        int footerRow = _products.Count + 5;

        _worksheet.Cell(footerRow, 1).Value = $"Products: {totalItems}";
        _worksheet.Range(footerRow, 1, footerRow, 2).Merge().Style.Font.Italic = true;
    }

    public XLWorkbook GetReport()
    {
        return _workbook;
    }
}
