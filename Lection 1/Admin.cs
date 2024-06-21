namespace Lection_1
{
    public class Admin : Person
    {
        private decimal AdminId;
        private string Role;
        public Admin(decimal AdminId, string Name, string Role) : base(AdminId, Name, AdminId)
        {
            this.Role = Role;
            this.AdminId = AdminId; 
        }

        public void AddClient(BankSystem Responsible, Person Client)
        {
            Responsible.AddClient(Client);
        }

        public void RemoveClient(BankSystem Responsible, Person Client)
        {
            Responsible.RemoveClient(Client);
        }

        public List<Transaction> ViewTransactions(BankSystem Responsible)
        {
            return Responsible.ViewTransactions();
        }

        public string GenerateReport(BankSystem Responsible, Transaction Transaction)
        {
            var Info = Transaction.GetTransactionDetails();
            string Report = $"\t\tREPORT\nTransaction info:\nTranscation ID: {Info.Id }\nCreate time: {Info.TimeInfo }\nAmount: {Info.Amount }";
            return Report;
        }
    }
}
