using Application.Interfaces;

namespace Application.Directors;

public class ExcelReportDirector
{
    private readonly IExcelReportBuilder _builder;

    public ExcelReportDirector(IExcelReportBuilder builder)
    {
        _builder = builder;
    }

    public void ConstructReport()
    {
        _builder.BuildHeader();
        _builder.BuildBody();
        _builder.BuildFooter();
    }
}
