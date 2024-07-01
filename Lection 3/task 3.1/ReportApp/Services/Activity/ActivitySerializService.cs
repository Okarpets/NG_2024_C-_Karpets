using ReportApp.Models.Activity;
using System.Text.Json;

namespace ReportApp.Services.Activity;

public class ActivityerializService
{
    private readonly TemplateManagerService _templateService = new TemplateManagerService();

    public ActivityReportModel SerializeReportModel(string path)
    {
        var jsonContent = File.ReadAllText(path);
        var model = JsonSerializer.Deserialize<ActivityReportModel>(jsonContent);
        return model;
    }
}
