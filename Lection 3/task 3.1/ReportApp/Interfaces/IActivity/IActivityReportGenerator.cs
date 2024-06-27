using ReportApp.Models.Activity;

namespace ReportApp.Interfaces.IActivity;

public interface IActivityReportGenerator
{
    public ActivityReportModel SerializeReportModel(string path);
    public void GenerateReport();
}
