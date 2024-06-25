namespace ReportApp.Models;

public class ClientAdminAssignment
{
    public Client Client { get; set; }
    public Admin Admin { get; set; }

    public ClientAdminAssignment(Client client, Admin admin)
    {
        Client = client;
        Admin = admin;
    }
}