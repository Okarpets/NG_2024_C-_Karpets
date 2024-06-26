using ReportApp.Models;
using System.Text.Json;

namespace ReportApp.Services;

public class PathConfigurationService
{
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
}
