using ReportApp.Models;
using System.Text.Json;

namespace ReportApp.Services;

public class ShopReportConfigurationService
{
    public ShopReportConfiguration LoadFromFile(string path)
    {
        var jsonContent = File.ReadAllText(path);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var test = JsonSerializer.Deserialize<ShopReportConfiguration>(jsonContent, options);
        return test;
    }

    public ShopReportConfiguration GetConfiguration(string path)
    {
        var configuration = LoadFromFile(path);
        return configuration;
    }
}
