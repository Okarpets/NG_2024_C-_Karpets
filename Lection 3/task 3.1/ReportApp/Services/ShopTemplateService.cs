using ClosedXML.Excel;
using ClosedXML.Report;
using ReportApp.Models;

namespace ReportApp.Services;

public class ShopTemplateService
{

    public XLTemplate GetReportTemplate()
    {
        return new(@"./Templates/ShopReport.xlsx");
    }

    public void CleanTestData(XLTemplate template, ShopReportConfiguration configuration, int actualLastColumn)
    {
        var worksheet = template.Workbook.Worksheets.First();
        for (int row = configuration.DefaultRow; row <= configuration.LastRow; row++)
        {
            for (int column = actualLastColumn; column <= configuration.LastColumn; column++)
            {
                worksheet.Cell(row, column).Clear();
            }
        }
    }

    public void DrawBorders(IXLWorksheet worksheet, ShopReportConfiguration configuration, int actualLastColumn)
    {
        var rightBorder = worksheet.Range(configuration.ReportTitleRow, actualLastColumn, configuration.LastRow, actualLastColumn);

        rightBorder.Style.Border.RightBorder = XLBorderStyleValues.Thin;
        rightBorder.Style.Border.RightBorderColor = XLColor.Black;

        var bottomBorder = worksheet.Range(configuration.LastRow, configuration.FirstColumn, configuration.LastRow, actualLastColumn);

        bottomBorder.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
        bottomBorder.Style.Border.BottomBorderColor = XLColor.Black;
    }
}