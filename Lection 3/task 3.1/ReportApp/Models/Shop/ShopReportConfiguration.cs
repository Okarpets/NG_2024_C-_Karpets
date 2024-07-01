namespace ReportApp.Models;

public class ShopReportConfiguration : ReportConfiguration
{
    public int numberColumnFirst { get; set; }

    public int numberColumnLast { get; set; }

    public string SavePath { get; } = "../../../Reports/ShopReport.xlsx";
}
