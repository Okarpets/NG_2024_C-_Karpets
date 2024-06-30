using ReportApp.Models.Activity;
using System.Text.Json;

namespace ReportApp.Services.Activity;

public class ActivityReportConfigurationService
{
    public ActivityReportConfiguration LoadFromFile(string path)
    {
        var jsonContent = File.ReadAllText(path);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var data = JsonSerializer.Deserialize<ActivityReportConfiguration>(jsonContent, options);
        return data;
    }

    public ActivityReportConfiguration GetConfiguration(string path)
    {
        var configuration = LoadFromFile(path);
        return configuration;
    }
}
