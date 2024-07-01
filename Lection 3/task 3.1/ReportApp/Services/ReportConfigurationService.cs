using ReportApp.Models;
using System.Text.Json;

namespace ReportApp.Services;

public class ReportConfigurationService
{
    public ShopReportConfiguration GetShopConfiguration(string path)
    {
        var jsonContent = File.ReadAllText(path);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var data = JsonSerializer.Deserialize<ShopReportConfiguration>(jsonContent, options);
        return data;
    }

    public ActivityReportConfiguration GetActivityConfiguration(string path)
    {
        var jsonContent = File.ReadAllText(path);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var data = JsonSerializer.Deserialize<ActivityReportConfiguration>(jsonContent, options);
        return data;
    }
}