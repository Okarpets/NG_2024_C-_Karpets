using ClosedXML.Excel;
using ClosedXML.Report;
using ReportApp.Models.Shop;

namespace ReportApp.Services.Shop;

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
                _ = worksheet.Cell(row, column).Clear();
            }
        }
    }

    public void DrawBorders(IXLWorksheet worksheet, ShopReportConfiguration configuration, int actualLastColumn, int initialLastRow)
    {

        for (int row = 7; row < configuration.LastRow - 1; row++)
        {
            for (int column = configuration.FirstColumn; column <= actualLastColumn - 1; column++)
            {
                worksheet.Cell(row, column).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(row, column).Style.Border.OutsideBorderColor = XLColor.Black;
            }
        }
    }

    public void FormatStyle(IXLWorksheet worksheet, ShopReportConfiguration configuration, int finishedRow)
    {
        for (int row = configuration.DefaultRow; row < finishedRow; row++)
        {
            if (row % 2 != 0)
            {
                for (int column = configuration.FirstColumn; column <= configuration.LastColumn - 1; column++)
                {
                    worksheet.Cell(row, column).Style.Fill.BackgroundColor = XLColor.WhiteSmoke;
                    worksheet.Cell(row, column).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                }
            }
            else
            {
                for (int column = configuration.FirstColumn; column <= configuration.LastColumn - 1; column++)
                {
                    worksheet.Cell(row, column).Style.Fill.BackgroundColor = XLColor.White;
                    worksheet.Cell(row, column).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                }
            }
        }
    }
}