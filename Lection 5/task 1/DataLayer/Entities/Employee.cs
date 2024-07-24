using DataLayer.Entities;

namespace task_1.Entities
{
    public class Employee : IEntity
    {
        public string Name { get; set; }

        public int Phone { get; set; }

        public decimal Salary { get; set; }

        public string Position { get; set; }

        public Guid StorageID { get; set; }

        public Storage Storage { get; set; }
    }
}
