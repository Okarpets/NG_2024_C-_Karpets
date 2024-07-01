namespace Lection_2_task_2._2.Models;

public class Genre
{
    public string Name { get; set; }

    public string Description { get; set; }

    public Genre(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
