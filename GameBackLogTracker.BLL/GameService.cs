using GameBackLogTracker.CORE.Interfaces;
using GameBackLogTracker.CORE.Models;

namespace GameBackLogTracker.BLL
{
    public class GameService : IGamesService
    {
        private IUnitOfWork _uow;
        public GameService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public Result<Games> AddGame(Games game)
        {
            throw new NotImplementedException();
        }

        public Result DeleteGame(int id)
        {
            throw new NotImplementedException();
        }

        public Result<List<Games>> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public Result<Games> GetGameById(int id)
        {
            throw new NotImplementedException();
        }

        public Result UpdateGame(int id, Games game)
        {
            throw new NotImplementedException();
        }
    }
}
