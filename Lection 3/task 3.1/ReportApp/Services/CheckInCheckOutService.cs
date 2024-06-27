using ReportApp.Models.Data;
using ReportApp.Models.Entity;

namespace ReportApp.Services;

public class CheckInCheckOutService
{
    public CheckInCheckOut CalculateWorkHours(Person client, DateTime startTime, DateTime endTime)
    {
        return new CheckInCheckOut
        {
            ClientCheckedIn = startTime,
            ClientCheckedOut = endTime
        };
    }
}
