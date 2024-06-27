using ClosedXML.Report;
using ReportApp.Models.Activity;

namespace ReportApp.Interfaces.IActivity;

public interface IActivityTemplateService
{
    public XLTemplate GetReportTemplate();
    public void FillSettings(ActivityReportModel model);
    public void FillHeader(XLTemplate template, ActivityReportConfiguration configuration);
}
