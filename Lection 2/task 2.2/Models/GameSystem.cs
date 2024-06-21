using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lection_2_task_2._2.Models;

public class GameSystem
{
    public Game GetById(List<Game> Games, decimal OrderedId) 
    {
        return Games.FirstOrDefault(x => x.Id == OrderedId);
    }

    public Dictionary<string, decimal> GetListByPriceRange(List<Game> Games, decimal OrderPriceMin, decimal OrderPriceMax) 
    {
        Dictionary<string, decimal> GameAndPrice = new Dictionary<string, decimal>();
        foreach (var Game in Games)
        {
            if (Game.Price >= OrderPriceMin && Game.Price <= OrderPriceMax)
            {
                GameAndPrice.Add(Game.Name, Game.Price);
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
             var GenresInGame = from g in Games select g.Genres;
        foreach (List<Genre> AllGanres in GenresInGame)
             {
                foreach (Genre Ganre in AllGanres)
                {
                    Result.Add(Ganre.Name);
                }
            }
        return Result.GroupBy(s => s).Where(g => g.Count() == 1).Select(g => g.Key).ToList();
    }

    public List<string> GetFilterGamesByCategoryAndGenres(List<Game> Games, List<string> Genres)
    {
        List<string> Result = new List<string>();
        var AllGames = from g in Games select g.Name;
        foreach (Game game in Games)
        {
            var HasIntersection = !Genres.Except(game.Genres.Select(x => x.Name)).Any();
            if (HasIntersection == true)
            {
                Result.Add(game.Name);
            }
        }
        return Result;
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
