using GameBackLogTracker.CORE.Enums;
using GameBackLogTracker.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using GameBackLogTracker.CORE.Models;

namespace GameBackLogTracker.UI
{
    public class Controller
    {
        private IGamesService _gamesService;
        private ConsoleIO _io;
        public Controller(IGamesService gamesService, ConsoleIO consoleIO)
        {
            _gamesService = gamesService;
            _io = consoleIO;
        }
        public void Run()
        {
            bool running = true;
            while (running)
            {
                AnsiConsole.MarkupLine("[blue][slowblink][link=https://github.com/jcundiff1993]View my other projects here.[/][/][/]");
                _io.DisplayProgramName();
                MenuChoice choice = _io.PromptMenuChoice();
                switch (choice)
                {
                    case MenuChoice.AddGame:
                        AddGame();
                        _io.ReturnToMenuPrompt();
                        break;
                    case MenuChoice.ViewAllGames:
                        ViewAllGames();
                        _io.ReturnToMenuPrompt();
                        break;
                    case MenuChoice.UpdateGame:
                        UpdateGame();
                        _io.ReturnToMenuPrompt();
                        break;
                    case MenuChoice.DeleteGame:
                        DeleteGame();
                        break;
                    case MenuChoice.ViewStats:
                        ViewStats();
                        break;
                    case MenuChoice.Exit:
                        running = false;
                        break;
                }
                _io.ReturnToMenuPrompt();
            }
        }
        private void ViewStats()
        {
            throw new NotImplementedException();
        }
        private void DeleteGame()
        {
            throw new NotImplementedException();
        }
        private void UpdateGame()
        {
            throw new NotImplementedException();
        }
        private void ViewAllGames()
        {
            Result<List<Games>> gamesResult = _gamesService.GetAllGames();
            foreach (Games game in gamesResult.Data)
            {
                Console.WriteLine($"ID: {game.Id}");
            }
        }
        private void AddGame()
        {
            Games newGame = _io.CreateGame();
            Result<Games> gameResult = _gamesService.AddGame(newGame);
            _io.Display(gameResult.Message);

        }
    }
}
