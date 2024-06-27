using ClosedXML.Excel;
using ClosedXML.Report;
using ReportApp.Models.Shop;

namespace ReportApp.Interfaces.IShop;

public interface IShopTemplateDrawing
{
    public void CleanTestData(XLTemplate template, ShopReportConfiguration configuration, int actualLastColumn);
    public void DrawBorders(IXLWorksheet worksheet, ShopReportConfiguration configuration, int actualLastColumn, int initialLastRow);
}
