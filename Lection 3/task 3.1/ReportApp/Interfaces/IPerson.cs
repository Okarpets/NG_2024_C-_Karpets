﻿namespace ReportApp.Interfaces;

public interface IPerson
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PreferedName { get; set; }
    public string Pronouns { get; set; }
    public string City { get; set; }
}
