using ReportApp.Interfaces;
using ReportApp.Models;
using System.Text.Json;

namespace ReportApp.Services;

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

    public ConfigurationModel LoadConfiguration(string path = @"./ReportConfigurations/Configuration.json")
    {
        var jsonContent = File.ReadAllText(path);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var test = JsonSerializer.Deserialize<ConfigurationModel>(jsonContent, options);
        return test;
    }

    public ActivityReportConfiguration GetConfiguration(string path)
    {
        var configuration = LoadFromFile(path);
        return configuration;
    }
}
