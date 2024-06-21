using System.IO.Pipes;

namespace Lection_1
{
    public class BankSystem
    {
        public List<Person> Clients { get; }
        public List<Transaction> Transactions;
        public BankSystem()
        {
            Clients = new List<Person>();
            Transactions = new List<Transaction>();
        }


        public void AddClient(Person Client)
        {
            Clients.Add(Client);
        }
        public List<Transaction> ViewTransactions()
        {
            return Transactions;
        }

        public void AddTransaction(Transaction transact)
        {
            Transactions.Add(transact);
        }
        public void RemoveClient(Person Client)
        {
            Clients.Remove(Client);
        }

        public void RemoveTransaction(Transaction Transact)
        {
            Transactions.Remove(Transact);
        }
    }
}