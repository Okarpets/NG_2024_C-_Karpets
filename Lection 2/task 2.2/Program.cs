using Lection_2_task_2._2.Models;
using System.Reflection.Metadata.Ecma335;

namespace Program;

internal class Program
{
    static public void Main(string[] args)
    {
        GameSystem gameSystem = new GameSystem();
        List<Game> gamesList = new List<Game>();
        while (true)
        {
            Console.WriteLine("Please, enter a command: ");
            string command = Convert.ToString(Console.ReadLine());
            switch (command)
            {
                case "-help":
                    Console.WriteLine(gameSystem.Commands());
                    break;
                case "-GBI":
                    Console.WriteLine("Enter an id of the game:");
                    decimal getById = Convert.ToDecimal(Console.ReadLine());
                    var gameById = gameSystem.GetById(gamesList, getById);
                    Console.WriteLine($"\tSEARCH RESULT\nName: {gameById.Name}\nPrice: {gameById.Price}\nCategory: {gameById.Category}\n\tGENRES");
                    foreach (Genre genre in gameById.Genres)
                    {
                        Console.WriteLine(genre.Name);
                    }
                    break;
                case "-GLBP":
                    Console.WriteLine("Enter min price of the game:");
                    decimal minPrice = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Enter max price of the game:");
                    decimal maxPrice = Convert.ToDecimal(Console.ReadLine());
                    var gamesByPrice = gameSystem.GetListByPriceRange(gamesList, minPrice, maxPrice);
                    foreach (Game game in gamesByPrice)
                    {
                        Console.WriteLine($"\tSEARCH RESULT\nName: {game.Name}\nPrice: {game.Price}\nCategory: {game.Category}\n\tGENRES");
                        foreach (Genre genre in game.Genres)
                        {
                            Console.WriteLine(genre.Name);
                        }
                    }
                    break;
                case "-GLBG":
                    Console.WriteLine("Enter name of the game:");
                    string nameOfGame = Convert.ToString(Console.ReadLine());
                    var ganres = gameSystem.GetListOfGenresByGame(gamesList, nameOfGame);
                    Console.WriteLine("GENRES");
                    foreach (Genre genre in ganres)
                    {
                        Console.WriteLine($"{genre.Name}");
                    }
                    break;
                case "-GUC":
                    var unique = gameSystem.GetUniqueCategoriesFromGameList(gamesList);
                    Console.WriteLine("Unique genres:");
                    foreach (Genre genre in unique)
                    {
                        Console.WriteLine($"{genre.Name}");
                    }
                    break;
                case "-Q":
                    gameSystem.Exit();
                    break;
                case "-GG":
                    List<string> genresToFilter = new List<string>();
                    while (true)
                    {
                        Console.WriteLine("Enter the genres to filtration:");
                        string ganreToFiltration = Convert.ToString(Console.ReadLine());
                        genresToFilter.Add(ganreToFiltration);
                        Console.WriteLine("Keep entering (Y/ )");
                        char order = Convert.ToChar(Console.ReadLine());
                        if (order == 'Y' || order == 'y') break;
                    }
                    var games = gameSystem.GetFilterGamesByCategoryAndGenres(gamesList, genresToFilter);
                    if (games == null)
                    {
                        Console.WriteLine("Game with this genres doesn't exist");
                        break;
                    }
                    Console.WriteLine("\tGAMES");
                    foreach (Game game in games)
                    {
                        Console.WriteLine($"{game.Name}");
                    }
                    break;
                default:
                    Console.WriteLine("It is a wrong command, please, use \"-help\"");
                    break;
            }
        }
    }
}