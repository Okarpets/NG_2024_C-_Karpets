using ClosedXML.Report;
using ReportApp.Models.Activity;
using ReportApp.Models.Entity;

namespace ReportApp.Interfaces.IActivity;

public interface IActivityReportData
{
    public void FillReportDataFromModel(XLTemplate template, ActivityReportConfiguration configuration, ActivityReportModel model);

    public ActivityReportModel GetReportModel(Person client, Admin? admin = null);
}
