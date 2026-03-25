using GameBackLogTracker.CORE.Interfaces;
using GameBackLogTracker.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackLogTracker.DAL.Mappers
{
    public class GameMapper : IMapper<Games>
    {
        public Games Deserialize(string input)
        {
            Games game = new Games();
            string[] fields = input.Split(',');
            game.Id = int.Parse(fields[0]);

            return game;
        }

        public string Serialize(Games games)
        {
            return $"{games.Id},{games.Name},{games.Genre},{games.Developer},{games.Publisher},{games.Description},{games.Platform}" +
                $"{games.ESRBRating},{games.Completed},{games.IsPlaying},{games.Playtime},{games.ReleaseDate}";
        }
    }
}
