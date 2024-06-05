namespace Lection_1
{
    public class Admin
    {
        public Admin(decimal adminID, string role) 
        {
            this.role = role;
            this.adminID = adminID; 
        }
        private decimal adminID;
        private string role;

        public void add_client(BankSystem responsible, Client client)
        {
            responsible.add_client(client);
        }

        public void remove_client(BankSystem responsible, Client client)
        {
            responsible.remove_client(client);
        }

        public List<Transaction> view_transactions(BankSystem responsible)
        {
            return responsible.view_transactions();
        }

        public string generate_report(BankSystem responsible, Transaction transaction)
        {
            var info = transaction.get_transaction_details();
            string report = $"\t\tREPORT\nTransaction info:\nTranscation ID: {info.id}\nCreate time: { info.timeinfo }\nAmount: { info.amount }";
            return report;
        }
    }
}
