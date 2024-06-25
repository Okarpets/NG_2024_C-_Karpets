using ReportApp.Models;

namespace ReportApp.Services;

public class AdminClientManager
{
    private readonly Admin _admin;
    private readonly List<Client> _clients;

    public AdminClientManager(Admin admin)
    {
        _admin = admin;
        _clients = new List<Client>();
    }

    public void AddClient(Client client)
    {
        _clients.Add(client);
    }

    public void RemoveClient(Client client)
    {
        _clients.Remove(client);
    }

    public List<Client> GetClients()
    {
        return new List<Client>(_clients);
    }
}
