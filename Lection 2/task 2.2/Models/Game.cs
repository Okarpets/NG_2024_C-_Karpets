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
    public Game(decimal id, string name, string category, decimal price, IEnumerable<Genre> genres)
    {
        this.id = id;
        this.name = name;
        this.category = category;
        this.price = price;
        this.genres = genres;
    }

    public decimal Id
    {
        get => id;
    }

    public string Name
    {
        get => name;
    }

    public string Category
    {
        get => category;
    }

    public decimal Price
    {
        get => price;
    }

    public IEnumerable<Genre> Genres
    {
        get => genres;
    }
}
