using ReportApp.Models.Activity;
using System.Text.Json;

namespace ReportApp.Services.Activity;

public class ActivitySerializService
{
    public ActivityReportModel SerializeReportModel(string path)
    {
        var jsonContent = File.ReadAllText(path);
        return JsonSerializer.Deserialize<ActivityReportModel>(jsonContent);
    }
}
