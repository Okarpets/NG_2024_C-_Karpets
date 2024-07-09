namespace Lection_2_task_2._2.Models;

public class Game
{
    public decimal Id { get; set; }

    public string Name { get; set; }

    public string Category { get; set; }

    public decimal Price { get; set; }

    public IEnumerable<Genre> Genres { get; set; }
}
