using Lection_2_task_2._2.Models;
using System.Reflection.Metadata.Ecma335;

namespace Program;

internal class Program
{
    static public void Main(string[] args)
    {
        GameSystem gameSystem = new GameSystem();
        while (true)
        {
            Console.WriteLine("Please, enter a command: ");
            string command = Convert.ToString(Console.ReadLine());
            switch (command)
            {
                case "-help":
                    Console.WriteLine(gameSystem.Commands());
                    break;
                case "GBI":
                    Console.WriteLine("Enter an id of the game:");
                    decimal getById = Convert.ToDecimal(Console.ReadLine());
                    var gameById = gameSystem.GetById(GameList.listOFGames, getById);
                    if (gameById != null)
                    { 
                    Console.WriteLine($"\tSEARCH RESULT\nName: {gameById.Name}\nPrice: {gameById.Price}\nCategory: {gameById.Category}\n\tGENRES");
                    foreach (Genre genre in gameById.Genres)
                    {
                        Console.WriteLine(genre.Name);
                    }
                    break;
                    }
                    Console.WriteLine("Game with this ID doesn't exist");
                    break;
                case "GLBP":
                    Console.WriteLine("Enter min price of the game:");
                    decimal minPrice = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Enter max price of the game:");
                    decimal maxPrice = Convert.ToDecimal(Console.ReadLine());
                    var gamesByPrice = gameSystem.GetListByPriceRange(GameList.listOFGames, minPrice, maxPrice);
                    if (gamesByPrice.Count() == 0)
                    {
                        Console.WriteLine("Game with this price range doesn't exist");
                        break;
                    }
                    foreach (var game in gamesByPrice)
                    {
                        Console.WriteLine($"Game name: {game.Key}\nPrice: {game.Value}");
                    }
                    break;
                case "GLBG":
                    Console.WriteLine("Enter name of the game:");
                    string nameOfGame = Convert.ToString(Console.ReadLine());
                    var ganres = gameSystem.GetListOfGenresByGame(GameList.listOFGames, nameOfGame);
                    Console.WriteLine("GENRES");
                    foreach (Genre genre in ganres)
                    {
                        Console.WriteLine($"{genre.Name}");
                    }
                    break;
                case "GUC":
                    var unique = gameSystem.GetUniqueCategoriesFromGameList(GameList.listOFGames);
                    if (unique.Count() == 0)
                    {
                        Console.WriteLine("Game with this unique genres doesn't exist");
                        break;
                    }
                    Console.WriteLine("Unique genres:");
                    foreach (string genre in unique)
                    {
                        Console.WriteLine($"{genre}");
                    }
                    break;
                case "Q":
                    Environment.Exit(1);
                    break;
                case "GG":
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
                    var games = gameSystem.GetFilterGamesByCategoryAndGenres(GameList.listOFGames, genresToFilter);
                    if (games.Count() == 0)
                    {
                        Console.WriteLine("Game with this genres doesn't exist");
                        break;
                    }
                    Console.WriteLine("\tGAMES");
                    foreach (string game in games)
                    {
                        Console.WriteLine($"{game}");
                    }
                    break;
                default:
                    Console.WriteLine("It is a wrong command, please, use \"-help\"");
                    break;
            }
        }
    }
}