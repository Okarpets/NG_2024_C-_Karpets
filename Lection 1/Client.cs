namespace Lection_1
{
    public class Client : Person
    {
        public decimal ClientId { get; set; }
        public string Name { get; set; }
        public decimal AccountNumber { get; set; }
        public Balance Balance { get; set; }
        public Client(decimal ClientId, string Name, decimal AccountNumber) : base(ClientId, Name, AccountNumber)
        {
            this.ClientId = ClientId;
            this.Name = Name;
            this.AccountNumber = AccountNumber;
            this.Balance = new Balance(AccountNumber, ClientId);
        }

        public void Deposit(decimal Amount)
        {
            decimal OldBalance = Balance.GetBalance();
            Balance.UpdateBalance(OldBalance += Amount);
        }

        public decimal GetBalance()
        {
            return Balance.GetBalance();
        }
    }
}
