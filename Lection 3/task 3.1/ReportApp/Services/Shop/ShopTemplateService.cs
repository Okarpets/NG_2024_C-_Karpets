using ClosedXML.Excel;
using ClosedXML.Report;
using ReportApp.Interfaces.IShop;
using ReportApp.Models.Shop;

namespace ReportApp.Services.Shop;

public class ShopTemplateService : IShopTemplateDrawing
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

    public void DrawBorders(IXLWorksheet worksheet, ShopReportConfiguration configuration, int actualLastColumn, int initialLastRow)
    {
        for (int row = initialLastRow; row < configuration.LastRow - 1; row++)
        {
            for (int column = configuration.FirstColumn; column <= actualLastColumn - 1; column++)
            {
                worksheet.Cell(row, column).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(row, column).Style.Border.OutsideBorderColor = XLColor.Black;
            }
        }
    }

    public void DrawColor(IXLWorksheet worksheet, int column, int currentRow)
    {
        if (currentRow % 2 == 0)
        {
            worksheet.Cell(currentRow, column).Style.Fill.BackgroundColor = XLColor.WhiteSmoke;
        }
        else
        {
            worksheet.Cell(currentRow, column).Style.Fill.BackgroundColor = XLColor.White;
        }
    }
}