using DataLayer.Entities;

namespace task_1.Entities
{
    public class Client : IEntity
    {
        public string Name { get; set; }

        public string Phone { get; set; }
    }
}
