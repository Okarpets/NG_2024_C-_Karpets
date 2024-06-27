using ReportApp.Services;
using ReportApp.Services.Activity;
using ReportApp.Services.Shop;


var request = new RequestsService();
var data = request.LoadConfiguration("./Request/Request.json");

switch (data.Type)
{
    case "Activity":
        var activityService = new ActivityReportGeneratorService();
        activityService.GenerateReport(data.PathToFile);
        break;
    case "Shop":
        var shopService = new ShopReportGeneratorService();
        shopService.GenerateReport(data.PathToFile);
        break;
    default:
        Console.WriteLine("Error, this type of reports doesn't exists");
        break;
}
