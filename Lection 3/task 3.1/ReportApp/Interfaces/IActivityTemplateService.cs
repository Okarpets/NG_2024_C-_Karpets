using ClosedXML.Report;
using ReportApp.Models;

namespace ReportApp.Interfaces;

public interface IActivityTemplateService
{
    public XLTemplate GetReportTemplate();
    public void FillSettings(ActivityReportModel model);
    public void FillHeader(XLTemplate template, ActivityReportConfiguration configuration);
}
