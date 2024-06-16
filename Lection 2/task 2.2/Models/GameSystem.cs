using System;
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

    public IEnumerable<Game> GetListByPriceRange(List<Game> games, decimal orderPriceMin, decimal orderPriceMax) 
    {
        var result = games.Where(x => x.Price <= orderPriceMax && x.Price >= orderPriceMin).OrderBy(x => x);
        return result;
    }
    public IEnumerable<Genre> GetListOfGenresByGame(List<Game> games, string gameName)
    { 
        if (games.Contains(games.FirstOrDefault(x => x.Name == gameName)))
        {
            return games.First(x => x.Name == gameName).Genres;
        }
        return null;
    }
    public List<Genre> GetUniqueCategoriesFromGameList(List<Game> games) 
    { 
        List<Genre> result = new List<Genre>();
        foreach (Game game in games)
        {
             var ganeresInGame = from g in games select g.Genres;
             foreach (Genre ganre in ganeresInGame)
             {
                result.Add(ganre);
             }
        }
        result.Distinct();
        return result;
    }
    public List<Game> GetFilterGamesByCategoryAndGenres(List<Game> games, List<string> genres)
    {
        List<Game> result = new List<Game>();
        foreach (Game game in games) 
        { 
            foreach (string genre in genres)
            {
                if (Convert.ToString(game.Genres.Select(x => x.Name)) == genre)
                {
                    result.Add(game);
                }
            }
        }
        result.Distinct();
        return result;
    }

    public void Exit()
    {
        Environment.Exit(1);
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
