using GameBackLogTracker.CORE.Enums;
using GameBackLogTracker.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

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
                MenuChoice choice = _io.PromptMenuChoice();
                switch (choice)
                {
                    case MenuChoice.AddGame:
                        AddGame();
                        break;
                    case MenuChoice.ViewAllGames:
                        ViewAllGames();
                        break;
                    case MenuChoice.UpdateGame:
                        UpdateGame();
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
            throw new NotImplementedException();
        }

        private void AddGame()
        {
            throw new NotImplementedException();
        }
    }
}
