namespace ReportApp.Models;

public class EfficiencyReportModel
{
    public Guid Id { get; set; }
    public EfficiencyReportSubject Subject { get; set; }
    public EfficiencyCompensationData Compensation { get; set; }
    public EfficiencyReportMetadata Metadata { get; set; }
}