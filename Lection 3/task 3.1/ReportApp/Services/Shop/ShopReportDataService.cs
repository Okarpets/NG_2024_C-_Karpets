using ClosedXML.Excel;
using ClosedXML.Report;
using ReportApp.Models;
using ReportApp.Models.Shop;

namespace ReportApp.Services.Shop;

public class ShopReportDataService
{
    private readonly TemplateManagerService _templateService = new TemplateManagerService();

    private Dictionary<string, Func<ShopReportModel, object>> KeyValuePairs { get; set; } = new Dictionary<string, Func<ShopReportModel, object>>
    {
        { "Name", r => r.PointOfPurchase },
        { "Seller", r => r.Seller },
        { "Items", r => r.Items }
    };

    public void FillReportDataFromModel(XLTemplate template, ReportConfiguration configuration, List<ShopReportModel> models)
    {
        var worksheet = template.Workbook.Worksheets.First();
        _ = worksheet.SetShowGridLines(false);

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
        _ = previousRange.Clear();

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
                for (int item = 0; item < model.Items.Count; item++)
                {
                    int column = firstDataColumn;
                    foreach (var property in KeyValuePairs)
                    {
                        if (property.Key.Equals("Items"))
                        {
                            worksheet.Cell(currentRow, column).Value = model.Items[item].Name;
                            worksheet.Cell(currentRow, column + 1).Value = model.Items[item].Quantity;
                            worksheet.Cell(currentRow, column + 2).Value = model.Items[item].Cost;
                            worksheet.Cell(currentRow, column + 3).Value = model.Items[item].Notes;
                        }
                        else
                        {
                            worksheet.Cell(currentRow, column).Value = property.Value(model).ToString();

                        }
                        column++;
                    }
                    currentRow++;
                    configuration.LastRow++;
                }
                finishedRow = currentRow;
            }

            var workingRange = worksheet.Range(configuration.ReportTitleRow, firstDataColumn, configuration.LastRow, lastDataColumn);
            _ = worksheet.Columns(configuration.FirstColumn, configuration.LastColumn).AdjustToContents();
        }

        _templateService.FormatStyle(worksheet, configuration, finishedRow);
        _templateService.DrawBorders(worksheet, configuration, "Shop", lastDataColumn, initialLastRow);
    }
}