using ClosedXML.Report;
using ReportApp.Models.Shop;

namespace ReportApp.Interfaces.IShop;

public interface IShopReportData
{
    public void FillReportDataFromModel(XLTemplate template, ShopReportConfiguration configuration, List<ShopReportModel> models);
}
