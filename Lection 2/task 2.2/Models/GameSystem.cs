namespace Lection_2_task_2._2.Models;

public class GameSystem
{
    public Game GetById(List<Game> Games, decimal OrderedId)
    {
        return Games.FirstOrDefault(x => x.Id == OrderedId);
    }

    public List<string> GetListByPriceRange(List<Game> Games, decimal OrderPriceMin, decimal OrderPriceMax)
    {
        List<string> GameAndPrice = new List<string>();
        foreach (var Game in Games)
        {
            if (Game.Price >= OrderPriceMin && Game.Price <= OrderPriceMax)
            {
                GameAndPrice.Add(Game.Name);
            }
        }
        return GameAndPrice;
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

    public List<string> GetFilterGamesByCategoryAndGenres(List<Game> games, List<string> genres, string category)
    {
        var result = new List<string>();
        foreach (var game in games)
        {
            if (game.Category == category && !genres.Except(game.Genres.Select(g => g.Name)).Any())
            {
                result.Add(game.Name);
            }
        }
        return result;
    }

    public void Pagination(List<string> Games)
    {
        List<List<string>> Page = new List<List<string>>();

        for (int Index = 0; Index < Games.Count; Index += 5)
        {
            List<string> part = Games.GetRange(Index, Math.Min(5, Games.Count - Index));
            Page.Add(part);
        }

        int PagesCount = ((int)Math.Round(Games.Count() / 5.0) * 5) / 5;

        if (PagesCount == 0)
        {
            PagesCount = 1;
        }

        if (Page.Count == 0)
        {
            Console.WriteLine("These games don't exist in list");
            return;
        }

        Console.WriteLine($"PAGES HAVE: {PagesCount}");

        while (true)
        {

            Console.WriteLine("Enter page for watching");
            int OrderPage = Convert.ToInt32(Console.ReadLine());
            if (OrderPage < 0 || OrderPage > PagesCount)
            {
                Console.WriteLine("This page doesn't exist");
                continue;
            }

            foreach (string part in Page[OrderPage - 1])
            {
                Console.WriteLine(part);
            }

            Console.WriteLine("Exit or watch another pages? (E/ )");
            char OrderExit = Convert.ToChar(Console.ReadLine());

            if (OrderExit == 'e' || OrderExit == 'E')
            {
                break;
            }
        }
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
