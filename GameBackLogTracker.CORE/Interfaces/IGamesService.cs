using GameBackLogTracker.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackLogTracker.CORE.Interfaces
{
    public interface IGamesService
    {
        public Result<Games> AddGame(Games game);
        public Result<Games> GetGameById(int id);
        public Result<List<Games>> GetAllGames();
        public Result UpdateGame(int id, Games game);
        public Result DeleteGame(int id);
    }
}
