using ReportApp.Services.Activity;
using ReportApp.Services.Shop;

namespace ReportApp.Services;

public class ReportGenerateService
{
    private readonly ConfigurationService _reportConfigurationService = new ConfigurationService();
    private readonly TemplateManagerService _templateService = new TemplateManagerService();

    private readonly ActivityTemplateManagerService _activityReportDataService = new ActivityTemplateManagerService();
    private readonly ShopTemplateManagerService _shopReportDataService = new ShopTemplateManagerService();

    private readonly ActivitySerializService _activitySerializService = new ActivitySerializService();
    private readonly ShopSerializService _shopSerializService = new ShopSerializService();

    public void GenerateReport(string pathToFile, string type)
    {
        Action action = type switch
        {
            "Activity" => () => GenerateActivityReport(pathToFile, type),
            "Shop" => () => GenerateShopReport(pathToFile, type),
            _ => throw new ArgumentException("It's a wrong report type"),
        };

        action();
    }

    private void GenerateActivityReport(string pathToFile, string type)
    {
        string pathToConfiguration = "./ReportConfigurations/Activity.json";

        var configuration = _reportConfigurationService.GetActivityConfiguration(pathToConfiguration);
        var activityTemplate = _templateService.GetReportTemplate(type);
        var activityModel = _activitySerializService.SerializeReportModel(pathToFile);

        _activityReportDataService.FillingAndFormattingExcel(activityTemplate, configuration, activityModel, type);
        _templateService.FillHeader(activityTemplate, configuration, activityModel);

        activityTemplate.Generate();
        activityTemplate.SaveAs(configuration.SavePath);
    }

    private void GenerateShopReport(string pathToFile, string type)
    {
        string pathToConfiguration = "./ReportConfigurations/Shop.json";

        var configuration = _reportConfigurationService.GetShopConfiguration(pathToConfiguration);
        var shopTemplate = _templateService.GetReportTemplate(type);
        var shopModels = _shopSerializService.SerializeReportModel(pathToFile);

        _shopReportDataService.FillingAndFormattingExcel(shopTemplate, configuration, shopModels, type);

        shopTemplate.Generate();
        shopTemplate.SaveAs(configuration.SavePath);
    }
}
