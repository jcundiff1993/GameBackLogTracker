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
        }
        public string PromptString(string message, bool isRequired = false)
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
        public bool PromptBool(string message, string answer)
        {
            return PromptString(message, true) == answer;
        }
        public DateOnly PromptDate(string message)
        {
            string input = PromptString(message, true);
            DateOnly result;
            while (DateOnly.TryParse(input, out result) == false)
            {
                DisplayError("Please enter a valid date (MM/DD/YYYY).");
                input = PromptString(message, true);
            }
            return result;
        }
    }
}
