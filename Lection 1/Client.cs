using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_1
{
    public class Client
    {
        public Client(decimal clientID, string name, decimal accountNumber) 
        {
            this.clientID = clientID;
            this.name = name;
            this.accountNumber = accountNumber;
            this.balance = new Balance(accountNumber, clientID);
        }

        private decimal clientID;
        private string name;
        private decimal accountNumber;
        private Balance balance;

        public string Name
        {
            get => name;
        }
        public Balance Balance
        { 
            get =>  balance;
        }
        public void deposit(decimal amount)
        {
            decimal oldBalance = balance.get_balance();
            balance.update_balance(oldBalance += amount);
        }

        public decimal get_balance()
        {
            return balance.get_balance();
        }
    }
}
