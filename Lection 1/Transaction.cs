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
        public Transaction()
        {
            GetTime();
        }

        private decimal amount;
        private decimal id;
        private string timeinfo;

        private void GetTime()
        {
            DateTime time = DateTime.Now;
            timeinfo = time.ToString("dd/MM/yyyy");
        }

        public void record_transaction(decimal amount, decimal id) 
        {
            this.id = id;
            this.amount = amount;
        }

        public (decimal amount, decimal id, string timeinfo) get_transaction_details()
        {
            return (amount : amount, id : id, timeinfo : timeinfo);
        }
    }
}
