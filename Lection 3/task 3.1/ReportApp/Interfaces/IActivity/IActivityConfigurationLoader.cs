using ReportApp.Models.Activity;

namespace ReportApp.Interfaces.IActivity;

public interface IActivityConfigurationLoader
{
    public ActivityReportConfiguration LoadFromFile(string path);
    public ActivityReportConfiguration GetConfiguration(string path);
}
