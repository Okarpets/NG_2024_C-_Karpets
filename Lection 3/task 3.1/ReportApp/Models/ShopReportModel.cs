namespace ReportApp.Models;

public class ShopReportModel
{
    public string PointOfPurchase { get; set; }
    public List<Item> Items { get; set; }
    public string Seller { get; set; }
}
