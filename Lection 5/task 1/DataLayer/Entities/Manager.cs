using DataLayer.Entities;

namespace task_1.Entities
{
    public class Manager : IEntity
    {
        public string Name { get; set; }

        public Storage Storage { get; set; }
    }
}
