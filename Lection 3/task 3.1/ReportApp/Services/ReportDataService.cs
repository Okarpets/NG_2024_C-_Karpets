using ClosedXML.Excel;
using ClosedXML.Report;
using ReportApp.Interfaces;
using ReportApp.Models;

namespace ReportApp.Services;

public class ReportDataService : IActivityReportData
{
    private readonly ActivityTemplateService _templateService = new ActivityTemplateService();

    private Dictionary<string, Func<ActivityReportModel, object>> KeyValuePairs { get; set; } = new Dictionary<string, Func<ActivityReportModel, object>>
    {
        { "FirstName", r => r.ReportGeneratedFor.FirstName },
        { "LastName", r => r.ReportGeneratedFor.LastName },
        { "Day", r => r.WorkdayStartTime.ToShortDateString() },
        { "Office", r => r.Office },
        { "Additional Info", r => r.Complains }
    };

    public void FillReportDataFromModel(XLTemplate template, ActivityReportConfiguration configuration, ActivityReportModel model)
    {
        var worksheet = template.Workbook.Worksheets.First();
        worksheet.SetShowGridLines(false);

        var firstDataRow = configuration.DefaultRow;
        var firstDataColumn = configuration.FirstColumn;

        var groupAmount = 2;
        var lastDataColumn = configuration.LastColumn;

        if (model.GeneratedByAdmin == null)
        {
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
        }
        else
        {
            KeyValuePairs.Add("Name", r => r.GeneratedByAdmin.PreferedName);
            KeyValuePairs.Add("Pronouns", r => r.GeneratedByAdmin.Pronouns);
            KeyValuePairs.Add("Works At", r => r.GeneratedByAdmin.City);
        }

        int initialLastRow = configuration.LastRow;

        for (int group = 1; group <= groupAmount; group++)
        {
            for (int row = 0; row < model.Complains.Count; row++)
            {
                int column = firstDataColumn;
                int currentRow = firstDataRow + row;

                foreach (var property in KeyValuePairs)
                {
                    if (property.Key.Equals("Additional Info"))
                    {
                        worksheet.Cell(currentRow, column).Value = model.Complains[row].Description;
                    }
                    else
                    {
                        worksheet.Cell(currentRow, column).Value = property.Value(model).ToString();
                    }

                    if (currentRow % 2 == 0)
                    {
                        worksheet.Cell(currentRow, column).Style.Fill.BackgroundColor = XLColor.WhiteSmoke;
                    }
                    else
                    {
                        worksheet.Cell(currentRow, column).Style.Fill.BackgroundColor = XLColor.White;
                    }

                    column++;
                }
                configuration.LastRow = Math.Max(configuration.LastRow, currentRow);
            }
        }

        var workingRange = worksheet.Range(configuration.ReportTitleRow, firstDataColumn, configuration.LastRow, lastDataColumn);
        worksheet.Columns(configuration.FirstColumn, configuration.LastColumn).AdjustToContents();

        _templateService.DrawBorders(worksheet, configuration, lastDataColumn, initialLastRow);
    }

    public ActivityReportModel GetReportModel(Person client, Admin? admin = null)
    {
        var today = DateTime.Now;
        var checkInCheckOut = new CheckInCheckOutService()
            .CalculateWorkHours(
                client,
                new DateTime(today.Year, today.Month, today.Day, 8, 0, 0),
                DateTime.Now);

        var reportModel = new ActivityReportModel()
        {
            GeneratedByAdmin = admin,
            Office = "New York, Wallstreet",
            GeneratedByClient = null,
            WorkdayStartTime = checkInCheckOut.ClientCheckedIn,
            WorkdayEndTime = checkInCheckOut.ClientCheckedOut,
            ReportGeneratedFor = client
        };

        _templateService.FillSettings(reportModel);

        return reportModel;
    }
}
