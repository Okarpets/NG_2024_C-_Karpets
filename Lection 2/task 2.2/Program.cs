using Lection_2_task_2._2.Models;

namespace Program;

internal class Program
{
    static public void Main(string[] args)
    {
        GameSystem GameSystem = new GameSystem();
        while (true)
        {
            Console.WriteLine("Please, enter a command: ");
            string Command = Convert.ToString(Console.ReadLine());
            switch (Command)
            {
                case "-help":
                    Console.WriteLine(GameSystem.Commands());
                    break;

                case "GBI":
                    Console.WriteLine("Enter an id of the game:");
                    decimal Id = Convert.ToDecimal(Console.ReadLine());
                    var GameById = GameSystem.GetById(GameList.ListOfGames, Id);
                    if (GameById != null)
                    {
                        Console.WriteLine($"\tSEARCH RESULT\nName: {GameById.Name}\nPrice: {GameById.Price}\nCategory: {GameById.Category}\n\tGENRES");
                        foreach (Genre Genre in GameById.Genres)
                        {
                            Console.WriteLine(Genre.Name);
                        }
                        break;
                    }
                    Console.WriteLine("Game with this ID doesn't exist");
                    break;

                case "GLBP":
                    Console.WriteLine("Enter min price of the game:");
                    decimal MinPrice = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Enter max price of the game:");
                    decimal MaxPrice = Convert.ToDecimal(Console.ReadLine());
                    var GamesByPrice = GameSystem.GetListByPriceRange(GameList.ListOfGames, MinPrice, MaxPrice);
                    if (GamesByPrice.Count() == 0)
                    {
                        Console.WriteLine("Game with this price range doesn't exist");
                        break;
                    }
                    byte IndexForGLBP = 1;
                    foreach (var Game in GamesByPrice)
                    {
                        if (IndexForGLBP == 1 || IndexForGLBP % 5 == 0)
                        {
                            Console.WriteLine($"PAGE N{IndexForGLBP}");
                        }
                        Console.WriteLine($"Game name: {Game.Key}\nPrice: {Game.Value}");
                        IndexForGLBP++;
                    }
                    break;

                case "GLBG":
                    Console.WriteLine("Enter name of the game:");
                    string NameOfGame = Convert.ToString(Console.ReadLine());
                    var Ganres = GameSystem.GetListOfGenresByGame(GameList.ListOfGames, NameOfGame);
                    Console.WriteLine("GENRES");
                    foreach (Genre Genre in Ganres)
                    {
                        Console.WriteLine($"{Genre.Name}");
                    }
                    break;

                case "GUC":
                    var Unique = GameSystem.GetUniqueCategoriesFromGameList(GameList.ListOfGames);
                    if (Unique.Count() == 0)
                    {
                        Console.WriteLine("Game with this unique genres doesn't exist");
                        break;
                    }
                    Console.WriteLine("Unique genres:");
                    foreach (string Genre in Unique)
                    {
                        Console.WriteLine($"{Genre}");
                    }
                    break;

                case "Q":
                    Environment.Exit(1);
                    break;

                case "GG":
                    List<string> GenresToFilter = new List<string>();
                    while (true)
                    {
                        Console.WriteLine("Enter the genres to filtration:");
                        string GanreToFiltration = Convert.ToString(Console.ReadLine());
                        GenresToFilter.Add(GanreToFiltration);
                        Console.WriteLine("Keep entering (Y/ )");
                        char Order = Convert.ToChar(Console.ReadLine());
                        if (Order == 'Y' || Order == 'y')
                        {
                            break;
                        }
                    }
                    var Games = GameSystem.GetFilterGamesByCategoryAndGenres(GameList.ListOfGames, GenresToFilter);
                    if (Games.Count() == 0)
                    {
                        Console.WriteLine("Game with this genres doesn't exist");
                        break;
                    }
                    Console.WriteLine("\tGAMES");
                    byte IndexByGG = 1;
                    foreach (string Game in Games)
                    {
                        if (IndexByGG == 1 || IndexByGG % 5 == 0)
                        {
                            Console.WriteLine($"PAGE {IndexByGG}");
                        }
                        Console.WriteLine($"{Game}");
                        IndexByGG++;
                    }
                    break;

                default:
                    Console.WriteLine("It is a wrong command, please, use \"-help\"");
                    break;
            }
        }
    }
}