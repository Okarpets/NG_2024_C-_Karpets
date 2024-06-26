using ReportApp.Models;
using System.Text.Json;

namespace ReportApp.Services;

public class ShopReportGeneratorService
{
    private readonly PathConfigurationService _pathConfigurationService = new PathConfigurationService();
    private readonly ShopReportConfigurationService _shopConfigurationService = new ShopReportConfigurationService();
    private readonly ConfigurationModel _configurationModel = new ConfigurationModel();
    private readonly ReportDataServiceShop _reportDataService = new ReportDataServiceShop();
    private readonly ShopTemplateService _templateService = new ShopTemplateService();

    public ShopReportModel SerializeReportModel(string path)
    {
        var jsonContent = File.ReadAllText(path);
        var model = JsonSerializer.Deserialize<ShopReportModel>(jsonContent);
        return model;
    }

    public void GenerateReport()
    {
        var template = _templateService.GetReportTemplate();

        var configuration = _pathConfigurationService.LoadConfiguration();

        var model = SerializeReportModel(configuration.ReportModel);

        _reportDataService.FillReportDataFromModel(template, _shopConfigurationService.GetConfiguration(configuration.KindOfConfigurationPath), model);

        template.Generate();
        template.SaveAs(configuration.PathToSave);
    }
}
