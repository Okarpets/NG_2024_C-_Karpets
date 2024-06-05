using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_1
{
    public class Balance
    {
        public Balance(decimal balanceID, decimal userID) 
        { 
            this.balanceID = balanceID;
            this.userID = userID;
        }
        private decimal balanceID;
        private decimal userID;
        private decimal amount;

       public decimal get_balance()
       {
            return amount;
       }

        public void update_balance(decimal amount)
        {
            this.amount = amount;
        }
    }
}