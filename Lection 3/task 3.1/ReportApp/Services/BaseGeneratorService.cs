using ReportApp.Models;
using ReportApp.Models.Activity;
using ReportApp.Services.Activity;

namespace ReportApp.Services;

public class BaseGeneratorService
{
    protected readonly ConfigurationService _reportConfigurationService = new ConfigurationService();
    protected readonly TemplateManagerService _templateService = new TemplateManagerService();

    protected readonly SerializeReportModel _serializService = new SerializeReportModel();

    public virtual void GenerateReport(string pathToFile, string type)
    {
        string pathToConfiguration = $"./ReportConfigurations/{type}.json";

        var configuration = _reportConfigurationService.LoadConfiguration<ActivityReportConfiguration>(pathToConfiguration);
        var activityTemplate = _templateService.GetReportTemplate(type);
        var activityModel = _serializService.SerializeModel<ActivityReportModel>(pathToFile);

        ActivityTemplateManagerService.FillingAndFormattingExcel(activityTemplate, configuration, activityModel, type);
        TemplateManagerService.FillHeader(activityTemplate, configuration, activityModel);

        activityTemplate.Generate();
        activityTemplate.SaveAs($"../../../Reports/{type}Report.xlsx");
    }
}
