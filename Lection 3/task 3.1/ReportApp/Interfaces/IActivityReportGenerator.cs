using ReportApp.Models;

namespace ReportApp.Interfaces;

public interface IActivityReportGenerator
{
    public ActivityReportModel SerializeReportModel(string path = @"./JsonExamples/ActivityReportClientGenerated.json");
    public void GenerateReport();
}
