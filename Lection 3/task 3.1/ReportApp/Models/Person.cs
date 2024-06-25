using ReportApp.Interfaces;

namespace ReportApp.Models;

public class Person : IPerson
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PreferedName { get; set; }
    public string Pronouns { get; set; }
    public string City { get; set; }
}
