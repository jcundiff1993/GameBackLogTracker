using GameBackLogTracker.CORE.Enums;
using GameBackLogTracker.CORE.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackLogTracker.UI
{
    public class ConsoleIO
    {
        public void Display(string message)
        {
            Console.WriteLine(message);
        }
        public void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public void ReturnToMenuPrompt()
        {
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
        }
        public string PromptString(string message, bool isRequired = true)
        {
            Console.Write(message);
            string result = Console.ReadLine();
            while (isRequired && string.IsNullOrWhiteSpace(result))
            {
                DisplayError("Input is required.");
                Display(message);
                result = Console.ReadLine();
            }
            return result;
        }
        public int PromptInt(string message, int min, int max)
        {
            string input = PromptString(message, true);
            int result;
            while (int.TryParse(input, out result) == false || result < min || result > max)
            {
                DisplayError($"Please enter a valid integer between {min} and {max}.");
                input = PromptString(message, true);
            }
            return result;
        }
        public double PromptDouble(string message, double min, double max)
        {
            string input = PromptString(message, true);
            double result;
            while (double.TryParse(input, out result) == false || result < min || result > max)
            {
                DisplayError($"Please enter a valid number between {min} and {max}.");
                input = PromptString(message, true);
            }
            return result;
        }
        public decimal PromptDecimal(string message, decimal min, decimal max)
        {
            string input = PromptString(message, true);
            decimal result;
            while (decimal.TryParse(input, out result) == false || result < min || result > max)
            {
                DisplayError($"Please enter a valid number between {min} and {max}.");
                input = PromptString(message, true);
            }
            return result;
        }
        public bool PromptBool(string message)
        {
            bool validAnswer = false;
            string answer = "";
            do
            {
                answer = PromptString(message + " Y = Yes, N = No ", true).ToLower();
                switch (answer)
                {
                    case "y":
                    case "n":
                        validAnswer = true;
                        break;
                    default:
                        DisplayError("Invalid entry.");
                        break;
                }
            }
            while (!validAnswer);
            return answer == "y" ? true : false;
        }
        public DateOnly PromptDate(string message)
        {
            string input = PromptString(message, true);
            string format = "MM/dd/yyyy";
            DateOnly result;
            while (DateOnly.TryParseExact(input, format, out result) == false)
            {
                DisplayError("Please enter a valid date (MM/DD/YYYY).");
                input = PromptString(message, true);
            }
            return result;
        }
        public void DisplayProgramName()
        {
            AnsiConsole.MarkupLine("[blue bold][slowblink]\r\n██████╗░░█████╗░░█████╗░██╗░░██╗██╗░░░░░░█████╗░░██████╗░████████╗██████╗░░█████╗░░█████╗░██╗░░██╗███████╗██████╗░\r\n██╔══██╗██╔══██╗██╔══██╗██║░██╔╝██║░░░░░██╔══██╗██╔════╝░╚══██╔══╝██╔══██╗██╔══██╗██╔══██╗██║░██╔╝██╔════╝██╔══██╗\r\n██████╦╝███████║██║░░╚═╝█████═╝░██║░░░░░██║░░██║██║░░██╗░░░░██║░░░██████╔╝███████║██║░░╚═╝█████═╝░█████╗░░██████╔╝\r\n██╔══██╗██╔══██║██║░░██╗██╔═██╗░██║░░░░░██║░░██║██║░░╚██╗░░░██║░░░██╔══██╗██╔══██║██║░░██╗██╔═██╗░██╔══╝░░██╔══██╗\r\n██████╦╝██║░░██║╚█████╔╝██║░╚██╗███████╗╚█████╔╝╚██████╔╝░░░██║░░░██║░░██║██║░░██║╚█████╔╝██║░╚██╗███████╗██║░░██║\r\n╚═════╝░╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝╚══════╝░╚════╝░░╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝[/][/]");
        }
        public MenuChoice PromptMenuChoice()
        {
            return (MenuChoice)PromptInt("1) Add Game\n2) View All Games\n3) Update Game\n4) Delete Game\n5) View Stats\n6) Exit\nPlease select an option: ", 1, 6);
        }

        public Games CreateGame()
        {
            Games game = new Games();
            game.Id = 0; // Id will be set by the database
            game.Name = PromptString("Enter game name:");
            game.Genre = PromptString("Enter game genre:");
            game.Developer = PromptString("Enter game developer (or N/A if unsure):");
            game.Publisher = PromptString("Enter game publisher (or N/A if unsure):");
            game.Description = PromptString("Enter game description:");
            game.Platform = PromptString("Enter game platform:");
            game.ESRBRating = PromptString("Enter ESRB rating (or N/A if unsure):");
            game.Completed = PromptBool("Have you completed the game?");
            game.IsPlaying = PromptBool("Are you currently playing the game?");
            game.Playtime = PromptDouble("Enter playtime in hours:", 0, double.MaxValue);
            string answer = PromptString("Do you know the release date? Y/N", true).ToLower();
            if (answer == "y")
            {
                game.ReleaseDate = PromptDate("Enter release date (MM/DD/YYYY):");
            }
            else
            {
                game.ReleaseDate = DateOnly.MinValue; // Use MinValue to indicate unknown release date
            }
            return game;
        }
    }
}
