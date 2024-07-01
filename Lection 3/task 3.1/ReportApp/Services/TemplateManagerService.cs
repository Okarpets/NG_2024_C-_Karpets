using ClosedXML.Excel;
using ClosedXML.Report;
using ReportApp.Models;
using ReportApp.Models.Activity;
using ReportApp.Models.Entity;

namespace ReportApp.Services;

public class TemplateManagerService
{
    private ActivityReportSettings Settings { get; set; }

    public XLTemplate GetReportTemplate(string type)
    {
        switch (type)
        {
            case "Activity":
                return new(@"./Templates/ActivityReport.xlsx");
            case "Shop":
                return new(@"./Templates/ShopReport.xlsx");
        }
        return new(@"./");
    }

    private void FillSettings(ActivityReportModel model)
    {
        Admin? generatedByAdmin = null;
        Client? generatedByClient = null;
        var generatedFor = $"{model.ReportGeneratedFor.FirstName}  {model.ReportGeneratedFor.LastName}";

        if (model.GeneratedByAdmin != null)
        {
            generatedByAdmin = model.GeneratedByAdmin;
        }
        else
        {
            generatedByClient = model.GeneratedByClient;
        }

        Settings = new ActivityReportSettings
        {
            GeneratedByAdmin = generatedByAdmin,
            GeneratedByClient = generatedByClient,
            GeneratedFor = generatedFor,
        };
    }

    public void FillHeader(XLTemplate template, ReportConfiguration configuration, ActivityReportModel activityModel)
    {
        FillSettings(activityModel);

        if (Settings != null)
        {
            var isGeneratedByAdmin = Settings.GeneratedByAdmin != null ? true : false;
            template.AddVariable("GeneratedFor", Settings.GeneratedFor);

            if (isGeneratedByAdmin)
            {
                template.AddVariable("GeneratedBy",
                    $"{Settings.GeneratedByAdmin.FirstName} {Settings.GeneratedByAdmin.LastName} (Admin)");
            }
            else
            {
                template.AddVariable("GeneratedBy",
                    $"{Settings.GeneratedByClient.FirstName} {Settings.GeneratedByClient.LastName} (Client)");
            }
        }
    }

    public void CleanTestData(XLTemplate template, ReportConfiguration configuration, int actualLastColumn)
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

    public void DrawBorders(IXLWorksheet worksheet, ReportConfiguration configuration, string type, int actualLastColumn, int initialLastRow)
    {
        switch (type)
        {
            case "Activity":
                break;
            case "Shop":
                configuration.LastRow -= 2;
                actualLastColumn--;
                break;

        }

        for (int row = 7; row <= configuration.LastRow; row++)
        {
            for (int column = configuration.FirstColumn; column <= actualLastColumn; column++)
            {
                worksheet.Cell(row, column).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(row, column).Style.Border.OutsideBorderColor = XLColor.Black;
            }
        }
    }

    public void FormatStyle(IXLWorksheet worksheet, ReportConfiguration configuration, int finishedRow)
    {
        for (int row = configuration.DefaultRow; row < finishedRow; row++)
        {
            if (row % 2 != 0)
            {
                for (int column = configuration.FirstColumn; column <= configuration.LastColumn - 1; column++)
                {
                    worksheet.Cell(row, column).Style.Fill.BackgroundColor = XLColor.WhiteSmoke;
                    if (column != 5 || column != 6)
                    {
                        worksheet.Cell(row, column).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        InCenter(worksheet, row, column);
                    }

                }
            }
            else
            {
                for (int column = configuration.FirstColumn; column <= configuration.LastColumn - 1; column++)
                {
                    worksheet.Cell(row, column).Style.Fill.BackgroundColor = XLColor.White;
                    if (column != 5 || column != 6)
                    {
                        worksheet.Cell(row, column).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        InCenter(worksheet, row, column);
                    }
                }
            }
        }
    }

    private void InCenter(IXLWorksheet worksheet, int row, int column)
    {
        if (column == 5 || column == 6)
        {
            worksheet.Cell(row, column).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        }
    }
}
