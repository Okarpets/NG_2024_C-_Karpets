using ReportApp.Interfaces.IActivity;
using ReportApp.Models.Activity;
using System.Text.Json;

namespace ReportApp.Services.Activity;

public class ActivityReportConfigurationService : IActivityConfigurationLoader
{
    public ActivityReportConfiguration LoadFromFile(string path)
    {
        var jsonContent = File.ReadAllText(path);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var test = JsonSerializer.Deserialize<ActivityReportConfiguration>(jsonContent, options);
        return test;
    }

    public ActivityReportConfiguration GetConfiguration(string path)
    {
        var configuration = LoadFromFile(path);
        return configuration;
    }
}
