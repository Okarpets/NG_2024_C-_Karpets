using DataLayer.Entities;

namespace task_1.Entities
{
    public class Category : IEntity
    {
        public string Description { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
