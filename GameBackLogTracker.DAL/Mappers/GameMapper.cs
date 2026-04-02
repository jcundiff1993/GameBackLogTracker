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
            game.Name = fields[1];
            game.Genre = fields[2];
            game.Developer = fields[3];
            game.Publisher = fields[4];
            game.Description = fields[5];
            game.Platform = fields[6];
            game.ESRBRating = fields[7];
            game.Completed = bool.Parse(fields[8]);
            game.IsPlaying = bool.Parse(fields[9]);
            game.Playtime = double.Parse(fields[10]);
            game.ReleaseDate = DateOnly.Parse(fields[11]);
            return game;
        }

        public string Serialize(Games games)
        {
            return $"{games.Id},{games.Name},{games.Genre},{games.Developer},{games.Publisher},{games.Description},{games.Platform},{games.ESRBRating},{games.Completed},{games.IsPlaying},{games.Playtime},{games.ReleaseDate}";
        }
    }
}
