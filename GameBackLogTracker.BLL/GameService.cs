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
            Result <Games> result = new Result<Games>();
            try
            {
                result.Data = _uow.GamesRepository.Create(game);
                _uow.Commit();
                result.Success = true;
                result.Message = $"{game.Name} was added successfully.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error occurred while adding the game: {ex.Message}";
            }
            return result;
        }

        public Result DeleteGame(int id)
        {
            Result result = new Result();

            try
            {
                _uow.GamesRepository.Delete(id);
                _uow.Commit();
                result.Success = true;
                result.Message = $"Game ID: {id} was deleted successfully.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error occurred while deleting the game: {ex.Message}";
            }
            return result;
        }

        public Result<List<Games>> GetAllGames()
        {
            Result<List<Games>> result = new Result<List<Games>>();
            try
            {
                result.Data = _uow.GamesRepository.ReadAll().ToList();
                result.Success = true;
                result.Message = "Games retrieved successfully.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error occurred while retrieving games: {ex.Message}";
            }
            return result;
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
