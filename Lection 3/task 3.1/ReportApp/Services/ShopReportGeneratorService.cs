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

    public List<ShopReportModel> SerializeReportModel(string path)
    {
        var jsonContent = File.ReadAllText(path);
        var models = JsonSerializer.Deserialize<List<ShopReportModel>>(jsonContent);
        return models;
    }

    public void GenerateReport()
    {
        var template = _templateService.GetReportTemplate();

        var configuration = _pathConfigurationService.LoadConfiguration();

        var models = SerializeReportModel(configuration.ReportModel);

        _reportDataService.FillReportDataFromModel(template, _shopConfigurationService.GetConfiguration(configuration.KindOfConfigurationPath), models);

        template.Generate();
        template.SaveAs(configuration.PathToSave);
    }
}
