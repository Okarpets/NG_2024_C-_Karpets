using ClosedXML.Excel;
using ClosedXML.Report;
using ReportApp.Models;

namespace ReportApp.Services;

public class ReportDataServiceShop
{
    private readonly ShopTemplateService _templateService = new ShopTemplateService();

    private Dictionary<string, Func<ShopReportModel, object>> KeyValuePairs { get; set; } = new Dictionary<string, Func<ShopReportModel, object>>
    {
        { "Name", r => r.PointOfPurchase },
        { "Quantity", r => r.Seller },
        { "Items", r => r.Items },
    };

    public void FillReportDataFromModel(XLTemplate template, ShopReportConfiguration configuration, ShopReportModel model)
    {
        var worksheet = template.Workbook.Worksheets.First();
        worksheet.SetShowGridLines(false);

        var firstDataRow = configuration.DefaultRow;
        var firstDataColumn = configuration.FirstColumn;

        var groupAmount = 2;
        var lastDataColumn = configuration.LastColumn;
        groupAmount = 1;
        lastDataColumn -= 3;
        worksheet.Range(configuration.FirstRowForDynamicGroup, lastDataColumn + 1, configuration.FirstRowForDynamicGroup, configuration.LastColumn)
            .Delete(XLShiftDeletedCells.ShiftCellsLeft);
        worksheet.Range(configuration.FirstRowForStaticGroup, lastDataColumn + 1, configuration.FirstRowForStaticGroup, configuration.LastColumn)
            .Delete(XLShiftDeletedCells.ShiftCellsLeft);


        var titleCell = worksheet.Cell(configuration.ReportTitleRow, firstDataColumn);
        var style = titleCell.Style;
        var title = titleCell.Value.ToString();

        var previousRange = worksheet.Range(configuration.ReportTitleRow, firstDataColumn, configuration.ReportTitleRow, configuration.LastColumn).Unmerge();
        previousRange.Clear();

        var newRange = worksheet.Range(configuration.ReportTitleRow, firstDataColumn, configuration.ReportTitleRow, lastDataColumn).Merge();
        newRange.Style = style;
        newRange.Value = title;

        _templateService.CleanTestData(template, configuration, lastDataColumn);
        if (configuration.LastColumn != lastDataColumn)
        {
            _templateService.DrawBorders(worksheet, configuration, lastDataColumn);
        }


        for (int group = 1; group <= groupAmount; group++)
        {
            for (int row = 0; row < model.Items.Count; row++)
            {
                int column = firstDataColumn;
                foreach (var property in KeyValuePairs)
                {
                    if (property.Key.Equals("Additional Info"))
                    {
                        worksheet.Cell(row + firstDataRow, column).Value = model.Items[row].Name;
                    }
                    else
                    {
                        worksheet.Cell(row + firstDataRow, column).Value = property.Value(model).ToString();
                    }
                    column++;
                }
                configuration.LastRow++;
            }

            var workingRange = worksheet.Range(configuration.ReportTitleRow, firstDataColumn, configuration.LastRow, lastDataColumn);
            worksheet.Columns(configuration.FirstColumn, configuration.LastColumn).AdjustToContents();
        }
    }

    public ShopReportModel GetReportModel()
    {
        var reportModel = new ShopReportModel()
        {
            PointOfPurchase = null,
            Seller = null,
            Items = null
        };

        return reportModel;
    }
}
