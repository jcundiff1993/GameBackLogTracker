using GameBackLogTracker.BLL;
using GameBackLogTracker.CORE;
using GameBackLogTracker.CORE.Interfaces;
using GameBackLogTracker.CORE.Models;
using GameBackLogTracker.DAL;
using GameBackLogTracker.DAL.Mappers;
using GameBackLogTracker.UI;

namespace GameBackLogTracker
{
    public class Program
    {
        static void Main(string[] args)
        {
            IMapper<Games> gameMapper = new GameMapper();
            IRepository<Games> gameRepo = new FileRepository<Games>("Games.csv", gameMapper);
            IUnitOfWork unitOfWork = new UnitOfWork(gameRepo);
            IGamesService gamesService = new GameService(unitOfWork);
            ConsoleIO io = new ConsoleIO();
            Controller controller = new Controller (gamesService, io);
            controller.Run();


        }
    }
}
