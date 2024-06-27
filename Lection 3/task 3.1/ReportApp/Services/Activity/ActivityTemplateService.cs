using ClosedXML.Excel;
using ClosedXML.Report;
using ReportApp.Interfaces.IActivity;
using ReportApp.Models.Activity;
using ReportApp.Models.Entity;

namespace ReportApp.Services.Activity;

public class ActivityTemplateService : IActivityTemplateService, IActivityTemplateDrawing
{
    private ActivityReportSettings Settings { get; set; }

    public XLTemplate GetReportTemplate()
    {
        return new(@"./Templates/ActivityReport.xlsx");
    }

    public void FillSettings(ActivityReportModel model)
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

    public void FillHeader(XLTemplate template, ActivityReportConfiguration configuration)
    {
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

    public void CleanTestData(XLTemplate template, ActivityReportConfiguration configuration, int actualLastColumn)
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

    public void DrawBorders(IXLWorksheet worksheet, ActivityReportConfiguration configuration, int actualLastColumn, int initialLastRow)
    {
        for (int row = initialLastRow; row <= configuration.LastRow; row++)
        {
            for (int column = configuration.FirstColumn; column <= actualLastColumn; column++)
            {
                worksheet.Cell(row, column).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(row, column).Style.Border.OutsideBorderColor = XLColor.Black;
            }
        }
    }
}
