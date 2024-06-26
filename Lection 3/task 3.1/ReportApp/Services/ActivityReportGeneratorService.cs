using ReportApp.Models;
using System.Text.Json;

namespace ReportApp.Services;

public class ActivityReportGeneratorService
{
    private readonly PathConfigurationService _pathConfigurationService = new PathConfigurationService();
    private readonly ActivityReportConfigurationService _activityConfigurationService = new ActivityReportConfigurationService();
    private readonly ConfigurationModel _configurationModel = new ConfigurationModel();
    private readonly ReportDataService _reportDataService = new ReportDataService();
    private readonly ActivityTemplateService _templateService = new ActivityTemplateService();

    public ActivityReportModel SerializeReportModel(string path)
    {
        var jsonContent = File.ReadAllText(path);
        var model = JsonSerializer.Deserialize<ActivityReportModel>(jsonContent);
        _templateService.FillSettings(model);
        return model;
    }

    public void GenerateReport()
    {
        var template = _templateService.GetReportTemplate();

        var configuration = _pathConfigurationService.LoadConfiguration();

        var model = SerializeReportModel(configuration.ReportModel);

        _reportDataService.FillReportDataFromModel(template, _activityConfigurationService.GetConfiguration(configuration.KindOfConfigurationPath), model);
        _templateService.FillHeader(template, _activityConfigurationService.GetConfiguration(configuration.KindOfConfigurationPath));

        template.Generate();
        template.SaveAs(configuration.PathToSave);
    }
}
