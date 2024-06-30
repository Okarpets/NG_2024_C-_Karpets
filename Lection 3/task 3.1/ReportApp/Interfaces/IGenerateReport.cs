using System.Text.Json;
namespace ReportApp.Interfaces;

public interface IGenerateReportService
{
    public virtual void GenerateReport(string pathToFile) { }
}
