using ReportApp.Models;
using System.Text.Json;

namespace ReportApp.Services;

public class ConfigurationService
{
    private JsonSerializerOptions SerializerOptions()
    {
        return new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public RequestModel LoadConfiguration(string path)
    {
        return JsonSerializer.Deserialize<RequestModel>(File.ReadAllText(path), SerializerOptions());
    }

    public ShopReportConfiguration GetShopConfiguration(string path)
    {
        return JsonSerializer.Deserialize<ShopReportConfiguration>(File.ReadAllText(path), SerializerOptions());
    }

    public ActivityReportConfiguration GetActivityConfiguration(string path)
    {
        return JsonSerializer.Deserialize<ActivityReportConfiguration>(File.ReadAllText(path), SerializerOptions());
    }
}