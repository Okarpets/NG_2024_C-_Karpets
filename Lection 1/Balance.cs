using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_1
{
    public class Balance
    {
        private decimal BalanceId;
        private decimal UserId;
        private decimal Amount;
        public Balance(decimal BalanceId, decimal UserId) 
        { 
            this.BalanceId = BalanceId;
            this.UserId = UserId;
        }
       public decimal GetBalance()
       {
            return Amount;
       }
        public void UpdateBalance(decimal Amount)
        {
            this.Amount = Amount;
        }
    }
}