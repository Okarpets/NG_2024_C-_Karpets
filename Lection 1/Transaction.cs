using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lection_1
{
    public class Transaction
    {
        private decimal Amount;
        private decimal Id;
        private string TimeInfo;
        public Transaction()
        {
            GetTime();
        }

        private void GetTime()
        {
            TimeInfo = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public void RecordTransaction(decimal Amount, decimal Id) 
        {
            Id = Id;
            Amount = Amount;
        }

        public (decimal Amount, decimal Id, string TimeInfo) GetTransactionDetails()
        {
            return (Amount: Amount, Id: Id, TimeInfo: TimeInfo);
        }
    }
}
