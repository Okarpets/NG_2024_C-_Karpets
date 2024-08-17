using DataLayer.Entities;

namespace task_1.Entities
{
    public class Storage : IEntity
    {
        public string Addres { get; set; }

        public decimal No { get; set; }

        public Guid ManagerID { get; set; }

        public Manager? Manager { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
