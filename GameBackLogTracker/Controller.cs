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
                        Console.Clear();
                        AddGame();
                        _io.ReturnToMenuPrompt();
                        break;
                    case MenuChoice.ViewAllGames:
                        Console.Clear();
                        ViewAllGames();
                        _io.ReturnToMenuPrompt();
                        break;
                    case MenuChoice.UpdateGame:
                        Console.Clear();
                        UpdateGame();
                        _io.ReturnToMenuPrompt();
                        break;
                    case MenuChoice.DeleteGame:
                        Console.Clear();
                        DeleteGame();
                        _io.ReturnToMenuPrompt();
                        break;
                    case MenuChoice.ViewStats:
                        Console.Clear();
                        ViewStats();
                        _io.ReturnToMenuPrompt();
                        break;
                    case MenuChoice.Exit:
                        running = false;
                        Console.Clear();
                        AnsiConsole.MarkupLine("[green bold]Thank you for using Backlog Tracker. Goodbye![/]");
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
            AnsiConsole.MarkupLine("[red bold]Delete Game[/]");
            int choice = _io.PromptInt("Search by name, or by ID? 1 = Name, 2 = Id ", 1, 2);
            Result<List<Games>> searchResult = _gamesService.GetAllGames();
            switch (choice)
            {
                case 1:
                    string name = _io.PromptString("Enter the name of the game you want to delete: ");
                    Games gamesToDelete = searchResult.Data.FirstOrDefault(g => g.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
                    if (gamesToDelete != null)
                    {
                        choice = _io.PromptInt($"Are you sure you want to delete '{gamesToDelete.Name}'? 1 = Yes, 2 = No ", 1, 2);
                        if (choice == 1)
                        {
                            Result deleteResult = _gamesService.DeleteGame(gamesToDelete.Id);
                            _io.Display(deleteResult.Message);
                        }
                        else
                        {
                            _io.Display("Deletion cancelled.");
                        }
                    }
                    else
                    {
                        _io.Display($"No game found with the name '{name}'.");
                    }
                    break;
                case 2:
                    int id = _io.PromptInt("Enter the ID of the game you want to delete: ", 1, int.MaxValue);
                    gamesToDelete = searchResult.Data.FirstOrDefault(i => i.Id.Equals(id));
                    if (gamesToDelete != null)
                    {
                        choice = _io.PromptInt($"Are you sure you want to delete '{gamesToDelete.Name}'? 1 = Yes, 2 = No ", 1, 2);
                        if (choice == 1)
                        {
                            Result deleteResult = _gamesService.DeleteGame(gamesToDelete.Id);
                            _io.Display(deleteResult.Message);
                        }
                        else
                        {
                            _io.Display("Deletion cancelled.");
                        }
                    }
                    else
                    {
                        _io.Display($"No game found with the id '{id}'.");
                    }
                    break;
                default:
                    _io.Display("Invalid choice. Returning to menu.");
                    break;
            }
        }
        private void UpdateGame()
        {
            throw new NotImplementedException();
        }
        private void ViewAllGames()
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[blue bold]All Games in Tracker:[/]");
            Result<List<Games>> gamesResult = _gamesService.GetAllGames();
            foreach (Games game in gamesResult.Data)
            {
                Console.WriteLine($"ID: {game.Id} | Name: {game.Name} | Platform: {game.Platform} | Completed?: {game.Completed}");
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
