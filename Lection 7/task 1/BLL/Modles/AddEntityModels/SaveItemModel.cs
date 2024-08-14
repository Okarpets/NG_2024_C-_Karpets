namespace BLL.Modles.AddEntityModels
{
    public class SaveItemModel
    {
        public Guid SenderId { get; set; }

        public Guid ReceiverId { get; set; }

        public decimal Weight { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public bool IsReceived { get; set; }

        public decimal Price { get; set; }

        public Guid StorageId { get; set; }

        public ICollection<Guid> Categories { get; set; }
    }
}
