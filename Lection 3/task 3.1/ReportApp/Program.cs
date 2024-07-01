using ReportApp.Services;


var request = new ConfigurationService();
var data = request.LoadConfiguration("./Request/Request.json");

switch (data.Type)
{
    case "Activity":
        var activityService = new ReportGenerateService();
        activityService.GenerateReport(data.PathToFile, data.Type);
        break;
    case "Shop":
        var shopService = new ReportGenerateService();
        shopService.GenerateReport(data.PathToFile, data.Type);
        break;
    default:
        Console.WriteLine("Error, this type of reports doesn't exists");
        break;
}
