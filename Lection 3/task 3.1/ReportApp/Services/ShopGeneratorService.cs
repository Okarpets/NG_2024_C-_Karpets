using ReportApp.Models;
using ReportApp.Models.Shop;
using ReportApp.Services.Shop;

namespace ReportApp.Services;

public class ShopGeneratorService : BaseGeneratorService
{
    public override void GenerateReport(string pathToFile, string type)
    {
        string pathToConfiguration = $"./ReportConfigurations/{type}.json";

        var configuration = _reportConfigurationService.LoadConfiguration<ShopReportConfiguration>(pathToConfiguration);
        var activityTemplate = _templateService.GetReportTemplate(type);
        var activityModel = _serializService.SerializeModel<List<ShopReportModel>>(pathToFile);

        ShopTemplateManagerService.FillingAndFormattingExcel(activityTemplate, configuration, activityModel, type);

        activityTemplate.Generate();
        activityTemplate.SaveAs($"../../../Reports/{type}Report.xlsx");
    }
}
