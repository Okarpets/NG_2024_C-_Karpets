using System.IO.Pipes;

namespace Lection_1
{
    public class BankSystem
    {
        public BankSystem()
        {
            clients = new List<Client>();
            transaction = new List<Transaction>();
        }

        private List<Client> clients;
        private List<Transaction> transaction;

        public List<Client> Clients
        {
            get => clients;
        }

        public void add_client(Client client)
        {
            clients.Add(client);
        }
        public List<Transaction> view_transactions()
        {
            return transaction;
        }

        public void add_transaction(Transaction transact)
        {
            transaction.Add(transact);
        }
        public void remove_client(Client client)
        {
            clients.Remove(client);
        }

        public void remove_transaction(Transaction transact)
        {
            transaction.Remove(transact);
        }
    }
}