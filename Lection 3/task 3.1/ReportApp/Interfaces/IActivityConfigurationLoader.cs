using ReportApp.Models;

namespace ReportApp.Interfaces;

public interface IActivityConfigurationLoader
{
    public ActivityReportConfiguration LoadFromFile(string path);
    public ActivityReportConfiguration GetConfiguration(string path);
}
