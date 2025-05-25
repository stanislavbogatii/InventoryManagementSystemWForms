using ClosedXML.Excel;

namespace Application.Interfaces
{
    public interface IExcelReportBuilder
    {
        void BuildHeader();
        void BuildBody();
        void BuildFooter();
        XLWorkbook GetReport();
    }
}
