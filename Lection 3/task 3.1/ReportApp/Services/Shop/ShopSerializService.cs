using ReportApp.Models.Shop;
using System.Text.Json;

namespace ReportApp.Services.Shop;

public class ShopSerializService
{
    public List<ShopReportModel> SerializeReportModel(string path)
    {
        return JsonSerializer.Deserialize<List<ShopReportModel>>(File.ReadAllText(path));
    }
}