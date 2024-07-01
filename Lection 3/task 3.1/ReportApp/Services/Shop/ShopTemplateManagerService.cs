using ClosedXML.Excel;
using ClosedXML.Report;
using ReportApp.Models;
using ReportApp.Models.Shop;

namespace ReportApp.Services.Shop;

public class ShopTemplateManagerService
{
    private readonly TemplateManagerService _templateService = new TemplateManagerService();

    private Dictionary<string, Func<ShopReportModel, object>> KeyValuePairs { get; set; } = new Dictionary<string, Func<ShopReportModel, object>>
    {
        { "Name", r => r.PointOfPurchase },
        { "Seller", r => r.Seller },
        { "Items", r => r.Items }
    };

    public void FillingAndFormattingExcel(XLTemplate template, ShopReportConfiguration configuration, List<ShopReportModel> models, string type)
    {
        var worksheet = template.Workbook.Worksheets.First();
        worksheet.SetShowGridLines(false);

        var firstDataRow = configuration.DefaultRow;
        var firstDataColumn = configuration.FirstColumn;

        var groupAmount = 1;
        var lastDataColumn = configuration.LastColumn;
        int initialLastRow = configuration.LastRow;

        worksheet.Range(configuration.FirstRowForDynamicGroup, lastDataColumn, configuration.FirstRowForDynamicGroup, configuration.LastColumn)
            .Delete(XLShiftDeletedCells.ShiftCellsLeft);
        worksheet.Range(configuration.FirstRowForStaticGroup, lastDataColumn, configuration.FirstRowForStaticGroup, configuration.LastColumn)
            .Delete(XLShiftDeletedCells.ShiftCellsLeft);

        var titleCell = worksheet.Cell(configuration.ReportTitleRow, firstDataColumn);
        var style = titleCell.Style;
        var title = titleCell.Value.ToString();

        var previousRange = worksheet.Range(configuration.ReportTitleRow, firstDataColumn, configuration.ReportTitleRow, configuration.LastColumn).Unmerge();
        previousRange.Clear();

        var newRange = worksheet.Range(configuration.ReportTitleRow, firstDataColumn, configuration.ReportTitleRow, lastDataColumn - 1).Merge();
        newRange.Style = style;
        newRange.Value = title;

        _templateService.CleanTestData(template, configuration, lastDataColumn);

        int currentRow = firstDataRow;
        int finishedRow = 0;

        foreach (var model in models)
        {
            for (int group = 1; group <= groupAmount; group++)
            {
                foreach (var item in model.Items)
                {
                    int column = firstDataColumn;
                    foreach (var property in KeyValuePairs)
                    {
                        if (property.Key.Equals("Items"))
                        {
                            foreach (var prop in item.GetType().GetProperties())
                            {
                                var value = prop.GetValue(item);
                                if (value is decimal || value is double || value is float || value is long || value is short)
                                {
                                    worksheet.Cell(currentRow, column).Value = Convert.ToInt32(value);
                                }
                                else
                                {
                                    worksheet.Cell(currentRow, column).Value = value?.ToString();
                                }
                                column++;
                            }
                        }
                        else
                        {
                            worksheet.Cell(currentRow, column).Value = property.Value(model).ToString();
                            column++;
                        }
                    }
                    currentRow++;
                    configuration.LastRow++;
                }
                finishedRow = currentRow;
            }

            var workingRange = worksheet.Range(configuration.ReportTitleRow, firstDataColumn, configuration.LastRow, lastDataColumn);
            worksheet.Columns(configuration.FirstColumn, configuration.LastColumn).AdjustToContents();
        }

        _templateService.FormatStyle(worksheet, configuration, finishedRow);
        _templateService.DrawBorders(worksheet, configuration, type, lastDataColumn, initialLastRow);
    }
}