using ReportApp.Models;
using System.Text.Json;

namespace ReportApp.Services;

public class ReportConfigurationService
{
    public ReportConfiguration LoadFromFile(string path)
    {
        var jsonContent = File.ReadAllText(path);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var data = JsonSerializer.Deserialize<ReportConfiguration>(jsonContent, options);
        return data;
    }

    public ReportConfiguration GetConfiguration(string path)
    {
        var configuration = LoadFromFile(path);
        return configuration;
    }
}