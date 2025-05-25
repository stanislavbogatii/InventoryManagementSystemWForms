using Application.DTOs.Product;
using Application.Builders;
using Application.Directors;
using Application.Interfaces;
using ClosedXML.Excel;

namespace Application.Facades
{
    public class ReportFacade
    {
        private readonly string logFilePath = "logs.txt";

        public XLWorkbook GenerateExcelReport(List<ProductDto> products, string reportType)
        {
            Log($"Starting report generation. Type: {reportType}, Products count: {products.Count}");

            IExcelReportBuilder builder;

            if (reportType == "Detailed report")
            {
                builder = new DetailedExcelReportBuilder(products);
            }
            else
            {
                builder = new ShortExcelReportBuilder(products);
            }

            var director = new ExcelReportDirector(builder);
            director.ConstructReport();

            var workbook = builder.GetReport();

            Log($"Report generation completed successfully. Type: {reportType}");
            return workbook;
        }

        private void Log(string message)
        {
            string logEntry = $"[{DateTime.Now}] [ReportFacade] {message}{Environment.NewLine}";
            File.AppendAllText(logFilePath, logEntry);
        }
    }
}
