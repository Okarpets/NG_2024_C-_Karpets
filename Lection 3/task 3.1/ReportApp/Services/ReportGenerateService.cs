using ReportApp.Services.Activity;
using ReportApp.Services.Shop;

namespace ReportApp.Services;

public class ReportGenerateService
{
    private readonly ReportConfigurationService _reportConfigurationService = new ReportConfigurationService();
    private readonly TemplateManagerService _templateService = new TemplateManagerService();

    private readonly ActivityReportDataService _activityReportDataService = new ActivityReportDataService();
    private readonly ShopReportDataService _shopReportDataService = new ShopReportDataService();

    private readonly ActivityerializService _activitySerializService = new ActivityerializService();
    private readonly ShopSerializService _shopSerializService = new ShopSerializService();

    public void GenerateReport(string pathToFile, string type)
    {
        string pathToConfiguration;
        string pathToSave;
        switch (type)
        {
            case "Activity":
                pathToConfiguration = "./ReportConfigurations/Activity.json";
                pathToSave = "../../../Reports/ActivityReport.xlsx";

                var activityTemplate = _templateService.GetReportTemplate(type);
                var activityModel = _activitySerializService.SerializeReportModel(pathToFile);

                _activityReportDataService.FillReportDataFromModel(activityTemplate, _reportConfigurationService.GetConfiguration(pathToConfiguration), activityModel);
                _templateService.FillHeader(activityTemplate, _reportConfigurationService.GetConfiguration(pathToConfiguration), activityModel);

                _ = activityTemplate.Generate();
                activityTemplate.SaveAs(pathToSave);
                break;

            case "Shop":
                pathToConfiguration = "./ReportConfigurations/Shop.json";
                pathToSave = "../../../Reports/ShopReport.xlsx";

                var shopTemplate = _templateService.GetReportTemplate(type);
                var shopModels = _shopSerializService.SerializeReportModel(pathToFile);

                _shopReportDataService.FillReportDataFromModel(shopTemplate, _reportConfigurationService.GetConfiguration(pathToConfiguration), shopModels);

                _ = shopTemplate.Generate();
                shopTemplate.SaveAs(pathToSave);
                break;
        }
    }
}
