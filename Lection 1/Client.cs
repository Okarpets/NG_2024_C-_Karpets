using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_1
{
    public class Client : Person
    {
        public decimal ClientId;
        public string Name { get; }
        public decimal AccountNumber;
        public Balance Balance {  get; }
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
