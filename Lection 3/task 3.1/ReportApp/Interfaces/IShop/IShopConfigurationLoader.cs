using ReportApp.Models.Shop;

namespace ReportApp.Interfaces.IShop;

public interface IShopConfigurationLoader
{
    public ShopReportConfiguration LoadFromFile(string path);
    public ShopReportConfiguration GetConfiguration(string path);
}
