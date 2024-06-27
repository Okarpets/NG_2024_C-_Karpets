using ReportApp.Models.Shop;

namespace ReportApp.Interfaces.IShop;

public interface IShopReportGenerator
{
    public ShopReportModel SerializeReportModel(string path);
    public void GenerateReport();
}
