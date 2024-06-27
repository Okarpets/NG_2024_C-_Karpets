using ReportApp.Interfaces;
using ReportApp.Models.Shop;
using System.Text.Json;

namespace ReportApp.Services.Shop;

public class ShopReportGeneratorService : IGenerateReport
{
    private readonly RequestsService _pathConfigurationService = new RequestsService();
    private readonly ShopReportConfigurationService _shopConfigurationService = new ShopReportConfigurationService();
    private readonly ShopReportDataService _reportDataService = new ShopReportDataService();
    private readonly ShopTemplateService _templateService = new ShopTemplateService();

    public List<ShopReportModel> SerializeReportModel(string path)
    {
        var jsonContent = File.ReadAllText(path);
        var models = JsonSerializer.Deserialize<List<ShopReportModel>>(jsonContent);
        return models;
    }

    public void GenerateReport(string pathToFile)
    {
        string pathToConfiguration = "./ReportConfigurations/Shop.json";
        string pathToSave = "../../../Reports/ShopReport.xlsx";

        var template = _templateService.GetReportTemplate();
        var models = SerializeReportModel(pathToFile);

        _reportDataService.FillReportDataFromModel(template, _shopConfigurationService.GetConfiguration(pathToConfiguration), models);

        template.Generate();
        template.SaveAs(pathToSave);
    }
}