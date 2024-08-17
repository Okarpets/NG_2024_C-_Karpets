using ReportApp.Models;
using ReportApp.Services;


var request = new ConfigurationService();
var data = request.LoadConfiguration<RequestModel>("./Request/Request.json");

switch (data.Type)
{
    case "Activity":
        var activityService = new ActivityGeneratorService();
        activityService.GenerateReport(data.PathToFile, data.Type);
        break;
    case "Shop":
        var shopService = new ShopGeneratorService();
        shopService.GenerateReport(data.PathToFile, data.Type);
        break;
    default:
        Console.WriteLine("Error, this type of reports doesn't exists");
        break;
}
