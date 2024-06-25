namespace ReportApp.Models;

public class EfficiencyReportSubject
{
    public Guid Id { get; set; }
    public Client Client { get; set; }
    public Admin Admin { get; set; }
}