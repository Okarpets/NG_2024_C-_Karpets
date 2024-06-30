using ClosedXML.Report;

namespace ReportApp.Interfaces;

public interface ITemplateService
{
    public XLTemplate GetReportTemplate();
}
