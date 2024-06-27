using ClosedXML.Excel;
using ClosedXML.Report;
using ReportApp.Models.Activity;

namespace ReportApp.Interfaces.IActivity;

public interface IActivityTemplateDrawing
{
    public void CleanTestData(XLTemplate template, ActivityReportConfiguration configuration, int actualLastColumn);
    public void DrawBorders(IXLWorksheet worksheet, ActivityReportConfiguration configuration, int actualLastColumn, int initialLastRow);
}
