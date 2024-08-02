using DataLayer.Entities;

namespace task_1.Entities
{
    public class Item : IEntity
    {
        public Guid SenderId { get; set; }

        public Guid ReceiverId { get; set; }

        public decimal Weight { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public bool IsReceived { get; set; }

        public decimal Price { get; set; }

        public Guid StorageId { get; set; }

        public Storage? Storage { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}