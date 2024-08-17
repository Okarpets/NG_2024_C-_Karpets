namespace Lection_1
{
    public class Transaction
    {
        private decimal Amount { get; set; }
        private decimal Id { get; set; }
        private string TimeInfo { get; set; }
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
