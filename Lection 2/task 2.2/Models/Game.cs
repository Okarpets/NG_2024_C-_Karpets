using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_2_task_2._2.Models;

public class Game
{
    private decimal id;
    private string name;
    private string category;
    private decimal price;
    private IEnumerable<Genre> genres;

    public decimal Id
    {
        get => id;
        set => id = value;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public string Category
    {
        get => category;
        set => category = value;

    }

    public decimal Price
    {
        get => price;
        set => price = value;
    }

    public IEnumerable<Genre> Genres
    {
        get => genres;
        set => genres = value;
    }
}
