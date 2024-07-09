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
                    if (GamesByPrice == null)
                    {
                        Console.WriteLine("Game with this price range doesn't exist");
                        break;
                    }
                    GameSystem.PageHandler(GamesByPrice, "Price");
                    break;

                case "GLBG":
                    Console.WriteLine("Enter name of the game:");
                    string NameOfGame = Convert.ToString(Console.ReadLine());
                    var Ganres = GameSystem.GetListOfGenresByGame(GameList.ListOfGames, NameOfGame);
                    if (Ganres == null)
                    {
                        Console.WriteLine("This game doesn't exists");
                        break;
                    }
                    foreach (Genre Genre in Ganres)
                    {
                        Console.WriteLine(Genre.Name);
                    }
                    break;

                case "GUC":
                    var Unique = GameSystem.GetUniqueCategoriesFromGameList(GameList.ListOfGames);
                    if (Unique.Count == 0)
                    {
                        Console.WriteLine("Unique category doesn't exist");
                    }
                    else
                    {
                        Console.WriteLine("Unique category:");
                        foreach (string Genre in Unique)
                        {
                            Console.WriteLine($"{Genre}");
                        }
                    }

                    break;

                case "Q":
                    Environment.Exit(1);
                    break;

                case "GG":
                    List<string> GenresToFilter = new List<string>();
                    Console.WriteLine("Enter the genres to filtration:");
                    while (true)
                    {
                        string GanreToFiltration = Convert.ToString(Console.ReadLine());
                        GenresToFilter.Add(GanreToFiltration);
                        Console.WriteLine("Stop entering (Y/ )");
                        char OrderGenres = Convert.ToChar(Console.ReadLine());
                        if (OrderGenres == 'Y' || OrderGenres == 'y')
                        {
                            break;
                        }
                    }
                    Console.WriteLine("Enter the category to filtration:");
                    string CategoryToFiltration = Convert.ToString(Console.ReadLine());
                    var GamesByFilter = GameSystem.GetFilterGamesByCategoryAndGenres(GameList.ListOfGames, GenresToFilter, CategoryToFiltration);
                    GameSystem.PageHandler(GamesByFilter, "Genres");
                    break;

                default:
                    Console.WriteLine("It is a wrong command, please, use \"-help\"");
                    break;
            }
        }
    }
}