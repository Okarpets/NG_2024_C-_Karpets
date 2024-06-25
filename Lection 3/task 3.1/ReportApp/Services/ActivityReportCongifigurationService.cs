using ReportApp.Models;
using System.Text.Json;

namespace ReportApp.Services;

public class ActivityReportConfigurationService
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

    public ActivityReportConfiguration GetConfiguration(string path = @"./ReportConfigurations/Activity.json")
    {
        var configuration = LoadFromFile(path);
        return configuration;
    }
}
