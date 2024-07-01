using ClosedXML.Excel;
using ClosedXML.Report;
using ReportApp.Models;
using ReportApp.Models.Activity;
using ReportApp.Models.Entity;

namespace ReportApp.Services;

public class TemplateManagerService
{
    private ActivityReportSettings Settings { get; set; }

    private XLTemplate ShopReportTemplate()
    {
        return new(@"./Templates/ShopReport.xlsx");
    }

    private XLTemplate ActivityReportTemplate()
    {
        return new(@"./Templates/ActivityReport.xlsx");
    }

    public XLTemplate GetReportTemplate(string type)
    {
        return type switch
        {
            "Activity" => ActivityReportTemplate(),
            "Shop" => ShopReportTemplate(),
            _ => throw new ArgumentException("It's a wrong report type"),
        };
    }

    private void FillSettings(ActivityReportModel model)
    {
        Admin? generatedByAdmin = null;
        Client? generatedByClient = null;

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
            GeneratedFor = $"{model.ReportGeneratedFor.FirstName}  {model.ReportGeneratedFor.LastName}"
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
                worksheet.Cell(row, column).Clear();
            }
        }
    }

    private void FormattingConfigToShop(ReportConfiguration configuration, ref int actualLastColumn)
    {
        configuration.LastRow -= 2;
        actualLastColumn--;
    }

    public void DrawBorders(IXLWorksheet worksheet, ReportConfiguration configuration, string type, int actualLastColumn, int initialLastRow)
    {
        Action action = type switch
        {
            "Activity" => () => { }
            ,
            "Shop" => () => FormattingConfigToShop(configuration, ref actualLastColumn),
            _ => throw new ArgumentException("It's a wrong report type"),
        };

        action();

        for (int row = configuration.ReportTitleRow; row <= configuration.LastRow; row++)
        {
            for (int column = configuration.FirstColumn; column <= actualLastColumn; column++)
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
                    if (column != configuration.numberColumnFirst || column != configuration.numberColumnLast)
                    {
                        worksheet.Cell(row, column).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        InCenter(worksheet, row, column, configuration);
                    }

                }
            }
            else
            {
                for (int column = configuration.FirstColumn; column <= configuration.LastColumn - 1; column++)
                {
                    worksheet.Cell(row, column).Style.Fill.BackgroundColor = XLColor.White;
                    if (column != configuration.numberColumnFirst || column != configuration.numberColumnLast)
                    {
                        worksheet.Cell(row, column).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        InCenter(worksheet, row, column, configuration);
                    }
                }
            }
        }
    }

    private void InCenter(IXLWorksheet worksheet, int row, int column, ShopReportConfiguration configuration)
    {
        if (column == configuration.numberColumnFirst || column == configuration.numberColumnLast)
        {
            worksheet.Cell(row, column).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        }
    }
}
