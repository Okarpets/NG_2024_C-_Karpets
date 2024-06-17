using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace Lection_2_task_2._2.Models;

static public class GameList
{
    static public List<string> allGenres = new List<string>()
    {
        "Indie",
        "Action",
        "Adventure",
        "Role-play",
        "Strategy",
        "Souls-like"
    };

    static public List<Game> listOFGames = new List<Game>()
    {
        new Game()
        {
            Id = 1,
            Name = "Hollow Knight",
            Category = "Platformer",
            Price = 329,
            Genres = new List<Genre>()
            {
                new Genre("Indie", "Games created by individuals or small teams who operate independently from major studios, both financially and creatively"),
                new Genre("Action", "Game where the player overcomes challenges by physical means such as precise aim and quick response times"),
                new Genre("Adventure", "Which the player assumes the role of a protagonist in an interactive story, driven by exploration and/or puzzle-solving")
            }
        },
        new Game()
        {
            Id = 2,
            Name = "Hollow Knight Silksong",
            Category = "Platformer",
            Price = 521,
            Genres = new List<Genre>()
            {
                new Genre("Indie", "Games created by individuals or small teams who operate independently from major studios, both financially and creatively"),
                new Genre("Action", "Game where the player overcomes challenges by physical means such as precise aim and quick response times"),
                new Genre("Adventure", "Which the player assumes the role of a protagonist in an interactive story, driven by exploration and/or puzzle-solving")
            }
        },
        new Game()
        {
            Id = 3,
            Name = "STALKER 2",
            Category = "Open-world",
            Price = 895,
            Genres = new List<Genre>()
            {
                new Genre("Role-play", "Games which each participant assumes the role of a character that can interact within the game's imaginary world"),
                new Genre("Action", "Game where the player overcomes challenges by physical means such as precise aim and quick response times"),
                new Genre("Adventure", "Which the player assumes the role of a protagonist in an interactive story, driven by exploration and/or puzzle-solving")
            }
        },
        new Game()
        {
            Id = 4,
            Name = "Baldur's Gate 3",
            Category = "Role-play",
            Price = 899,
            Genres = new List<Genre>()
            {
                new Genre("Role-play", "Games which each participant assumes the role of a character that can interact within the game's imaginary world"),
                new Genre("Action", "Game where the player overcomes challenges by physical means such as precise aim and quick response times"),
                new Genre("Strategy", "Typically larger in scope, and their main emphasis is on the player's ability to outthink their opponent")
            }
        },
        new Game()
        {
            Id = 5,
            Name = "South Park: The Fractured But Whole",
            Category = "Strategy",
            Price = 649,
            Genres = new List<Genre>()
            {
                new Genre("Role-play", "Games which each participant assumes the role of a character that can interact within the game's imaginary world")
            }
        },
        new Game()
        {
            Id = 6,
            Name = "Cyberpunk 2077",
            Category = "Open-world",
            Price = 1099,
            Genres = new List<Genre>()
            {
                new Genre("Role-play", "Games which each participant assumes the role of a character that can interact within the game's imaginary world"),
                new Genre("Action", "Game where the player overcomes challenges by physical means such as precise aim and quick response times"),
                new Genre("Adventure", "Which the player assumes the role of a protagonist in an interactive story, driven by exploration and/or puzzle-solving")
            }
        },
        new Game()
        {
            Id = 7,
            Name = "Red Dead Redemption 2",
            Category = "Open-world",
            Price = 899,
            Genres = new List<Genre>()
            {
                new Genre("Action", "Game where the player overcomes challenges by physical means such as precise aim and quick response times"),
                new Genre("Adventure", "Which the player assumes the role of a protagonist in an interactive story, driven by exploration and/or puzzle-solving")
            }
        },
        new Game()
        {
            Id = 8,
            Name = "The Witcher 3: Wild Hunt",
            Category = "Open-world",
            Price = 729,
            Genres = new List<Genre>()
            {
                new Genre("Role-play", "Games which each participant assumes the role of a character that can interact within the game's imaginary world")
            }
        },
        new Game()
        {
            Id = 9,
            Name = "Mortal Kombat 1",
            Category = "Fighting",
            Price = 1849,
            Genres = new List<Genre>()
            {
                new Genre("Action", "Game where the player overcomes challenges by physical means such as precise aim and quick response times")
            }
        },
        new Game()
        {
            Id = 10,
            Name = "Dark Souls",
            Category = "Action",
            Price = 321,
            Genres = new List<Genre>()
            {
                new Genre("Action", "Game where the player overcomes challenges by physical means such as precise aim and quick response times"),
                new Genre("Souls-like", "Dark fantasy setting and lack of overt storytelling, as well as their deep worldbuilding")
            }
        }
    };
}