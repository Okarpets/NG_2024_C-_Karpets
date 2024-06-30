using ReportApp.Models.Shop;
using System.Text.Json;

namespace ReportApp.Services.Shop;

public class ShopReportConfigurationService
{
    public ShopReportConfiguration LoadFromFile(string path)
    {
        var jsonContent = File.ReadAllText(path);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var data = JsonSerializer.Deserialize<ShopReportConfiguration>(jsonContent, options);
        return data;
    }

    public ShopReportConfiguration GetConfiguration(string path)
    {
        var configuration = LoadFromFile(path);
        return configuration;
    }
}
