using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicalCollection.UserInterface
{
    public class UserInterfaceService
    {
        //coloring output to the user
        public void SetDefaultConsoleColor() => 
            Console.ForegroundColor = ConsoleColor.White;
        public void PrintErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {message}");
            SetDefaultConsoleColor();
        }
        public void PrintFormatErrorMessage(string command, 
            string firstAppending = "", string secondAppending = "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Invalid format. Use: {command} {firstAppending} {secondAppending}");
            SetDefaultConsoleColor();
        }
        public void PrintSuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            SetDefaultConsoleColor();
        }
        public void PrintWarningMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            SetDefaultConsoleColor();
        }
        public void PrintBlueMessage(string message) 
        {
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine(message);
            SetDefaultConsoleColor();
        }
        public void PrintCyanMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            SetDefaultConsoleColor();
        }
        public void ClearConsole() => Console.Clear();
    }
}
