using ClosedXML.Excel;
using ClosedXML.Report;
using ReportApp.Models;

namespace ReportApp.Interfaces;

public interface IActivityTemplateDrawing
{
    public void CleanTestData(XLTemplate template, ActivityReportConfiguration configuration, int actualLastColumn);
    public void DrawBorders(IXLWorksheet worksheet, ActivityReportConfiguration configuration, int actualLastColumn, int initialLastRow);
}
