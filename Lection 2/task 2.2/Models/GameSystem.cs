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
    public Game GetById(List<Game> games, decimal orderedId) 
    { 
        return games.Where(x => x.Id == orderedId).FirstOrDefault();
    }

    public Dictionary<string, decimal> GetListByPriceRange(List<Game> games, decimal orderPriceMin, decimal orderPriceMax) 
    {
        Dictionary<string, decimal> gameAndPrice = new Dictionary<string, decimal>();
        foreach (var game in games)
        {
            if (game.Price >= orderPriceMin && game.Price <= orderPriceMax)
            {
                gameAndPrice.Add(game.Name, game.Price);
            }
        }
        return gameAndPrice;
    }
    public IEnumerable<Genre> GetListOfGenresByGame(List<Game> games, string gameName)
    { 
        if (games.Contains(games.FirstOrDefault(x => x.Name == gameName)))
        {
            return games.First(x => x.Name == gameName).Genres;
        }
        return null;
    }
    public List<string> GetUniqueCategoriesFromGameList(List<Game> games) 
    { 
        List<string> result = new List<string>();
             var genresInGame = from g in games select g.Genres;
        foreach (List<Genre> allGanres in genresInGame)
             {
                foreach (Genre ganre in allGanres)
                {
                    result.Add(ganre.Name);
                }
            }
        return result
            .GroupBy(s => s)         
            .Where(g => g.Count() == 1)
            .Select(g => g.Key)        
            .ToList();
    }

    //


    public List<string> GetFilterGamesByCategoryAndGenres(List<Game> games, List<string> genres)
    {
        List<string> result = new List<string>();
        var allGames = from g in games select g.Name;
        foreach (Game game in games)
        {
            var hasIntersection = !genres.Except(game.Genres.Select(x => x.Name)).Any();
            if (hasIntersection == true)
            {
                result.Add(game.Name);
            }
        }
        return result;
    }

    public string Commands()
    {
            string command =
            "* Q - exit\n" +
            "* GBI - Get a game by id\n" +
            "* GLBP - Get list of games by price range\n" +
            "* GLBG - Get list of genres by game\n" +
            "* GUC - Get unique categories from game list\n" +
            "* GG - Get filter games by genres\n";
        return command;
    }
}
