using ClosedXML.Report;
using ReportApp.Models;
namespace ReportApp.Interfaces;

public interface IActivityReportData
{
    public void FillReportDataFromModel(XLTemplate template, ActivityReportConfiguration configuration, ActivityReportModel model);

    public ActivityReportModel GetReportModel(Person client, Admin? admin = null);
}
