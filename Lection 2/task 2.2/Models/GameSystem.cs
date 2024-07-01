namespace Lection_2_task_2._2.Models;

public class GameSystem
{
    private readonly byte PageSize = 5;
    public Game GetById(List<Game> Games, decimal OrderedId)
    {
        return Games.FirstOrDefault(x => x.Id == OrderedId);
    }

    public List<string> GetListByPriceRange(List<Game> Games, decimal OrderPriceMin, decimal OrderPriceMax)
    {
        return Games.Where(Game => Game.Price <= OrderPriceMax && Game.Price >= OrderPriceMin).Select(Game => Game.Name).ToList();
    }

    public IEnumerable<Genre> GetListOfGenresByGame(List<Game> Games, string GameName)
    {
        if (Games.Any(x => x.Name == GameName))
        {
            return Games.First(x => x.Name == GameName).Genres;
        }
        return null;
    }

    public List<string> GetUniqueCategoriesFromGameList(List<Game> Games)
    {
        List<string> Result = new List<string>();
        Result.AddRange(Games.Select(g => g.Category));
        return Result.GroupBy(s => s).Where(g => g.Count() == 1).Select(g => g.Key).ToList();
    }

    public List<string> GetFilterGamesByCategoryAndGenres(List<Game> Games, List<string> genres, string category)
    {
        return Games.Where(Game => Game.Category == category && !genres.Except(Game.Genres.Select(g => g.Name)).Any()).Select(Game => Game.Name).ToList();
    }

    public int GetPageCount(List<string> Games)
    {
        return (int)Math.Ceiling((double)Games.Count / PageSize);
    }

    public void PageHandler(List<string> Data, string Type)
    {
        var PageCount = GetPageCount(Data);

        while (true)
        {
            Console.WriteLine($"Please enter a page (All pages: {PageCount})");
            int IndexOfPage = Convert.ToInt32(Console.ReadLine());
            var Paginaion = Pagination(Data, IndexOfPage);

            if (Paginaion.Count == 0)
            {
                Console.WriteLine("Page with this index range doesn't exist");
                return;
            }
            else
            {
                Console.WriteLine(Type == "Price" ? "GAMES" : "GENRES");
                foreach (string Value in Paginaion)
                {
                    Console.WriteLine(Value);
                }
            }
            Console.WriteLine("Do you want to stop GLBP command? (Y/ )");
            char Order = Convert.ToChar(Console.ReadLine());
            if (Order == 'Y' || Order == 'y')
            {
                return;
            }
        }
    }

    public List<string> Pagination(List<string> Games, int PageNumber)
    {
        return Games.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
    }

    public string Commands()
    {
        string Command =
        "* Q - exit\n" +
        "* GBI - Get a game by id\n" +
        "* GLBP - Get list of games by price range\n" +
        "* GLBG - Get list of genres by game\n" +
        "* GUC - Get unique categories from game list\n" +
        "* GG - Get filter games by genres\n";
        return Command;
    }
}
