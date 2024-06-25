using ReportApp.Models;
using System.Text.Json;

namespace ReportApp.Services;

public class ActivityReportGeneratorService
{
    private readonly ActivityReportConfigurationService _activityConfigurationService = new ActivityReportConfigurationService();
    private readonly ReportDataService _reportDataService = new ReportDataService();
    private readonly TemplateService _templateService = new TemplateService();

    public ActivityReportModel SerializeReportModel(string path = @"./JsonExamples/ActivityReportClientGenerated.json")
    {
        var jsonContent = File.ReadAllText(path);
        var model = JsonSerializer.Deserialize<ActivityReportModel>(jsonContent);
        _templateService.FillSettings(model);
        return model;
    }

    static void ExtractKeys(JsonElement element, List<string> keys, string parentKey = "")
    {
        if (element.ValueKind == JsonValueKind.Object)
        {
            foreach (JsonProperty property in element.EnumerateObject())
            {
                string currentKey = string.IsNullOrEmpty(parentKey) ? property.Name : $"{parentKey}.{property.Name}";
                keys.Add(currentKey);
                ExtractKeys(property.Value, keys, currentKey);
            }
        }
        else if (element.ValueKind == JsonValueKind.Array)
        {
            foreach (JsonElement arrayElement in element.EnumerateArray())
            {
                ExtractKeys(arrayElement, keys, parentKey);
            }
        }
    }

    public void GenerateReport()
    {
        var template = _templateService.GetReportTemplate();

        var client = new Client
        {
            FirstName = "John",
            LastName = "Snow",
            PreferedName = "THE TRUE KING",
            City = "Winterfell",
            Pronouns = "King/Wifey"
        };

        var admin = new Admin()
        {
            FirstName = "Soul",
            LastName = "Of Cinder",
            PreferedName = "Keeper of the flame",
            City = "Kiln Of The First Flame",
            Pronouns = "So so boss"
        };

        var model = SerializeReportModel();

        _reportDataService.FillReportDataFromModel(template, _activityConfigurationService.GetConfiguration(), model);
        _templateService.FillHeader(template, _activityConfigurationService.GetConfiguration());

        template.Generate();
        template.SaveAs("../../../Reports/Report.xlsx");
    }
}
