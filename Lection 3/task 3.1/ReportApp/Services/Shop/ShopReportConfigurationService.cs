using ReportApp.Interfaces.IShop;
using ReportApp.Models.Shop;
using System.Text.Json;

namespace ReportApp.Services.Shop;

public class ShopReportConfigurationService : IShopConfigurationLoader
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
