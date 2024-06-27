using ReportApp.Interfaces;
using ReportApp.Models.Activity;
using System.Text.Json;

namespace ReportApp.Services.Activity;

public class ActivityReportGeneratorService : IGenerateReport
{
    private readonly RequestsService _pathConfigurationService = new RequestsService();
    private readonly ActivityReportConfigurationService _activityConfigurationService = new ActivityReportConfigurationService();
    private readonly ActivityReportDataService _reportDataService = new ActivityReportDataService();
    private readonly ActivityTemplateService _templateService = new ActivityTemplateService();

    public ActivityReportModel SerializeReportModel(string path)
    {
        var jsonContent = File.ReadAllText(path);
        var model = JsonSerializer.Deserialize<ActivityReportModel>(jsonContent);
        _templateService.FillSettings(model);
        return model;
    }

    public void GenerateReport(string pathToFile)
    {
        string pathToConfiguration = "./ReportConfigurations/Activity.json";
        string pathToSave = "../../../Reports/ActivityReport.xlsx";

        var template = _templateService.GetReportTemplate();
        var model = SerializeReportModel(pathToFile);

        _reportDataService.FillReportDataFromModel(template, _activityConfigurationService.GetConfiguration(pathToConfiguration), model);
        _templateService.FillHeader(template, _activityConfigurationService.GetConfiguration(pathToConfiguration));

        template.Generate();
        template.SaveAs(pathToSave);
    }
}
