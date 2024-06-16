using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lection_2_task_2._2.Models;
public class Genre
{
    private string name;
    private string description;
    public Genre(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }
    public string Description
    {
        get => description;
        set => description = value;
    }
}
