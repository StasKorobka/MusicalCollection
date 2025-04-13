using MusicalCollection.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicalCollection.UserInterface;
using System.Text;
namespace MusicalCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var context = new MusicalCollectionDbContext();//DB
            var service = new MusicCollectionService(context);//DB controller
            var UI = new UserInterfaceService();//console output 
            var commandHandler = new CommandHandler(service, userId: 1);//for testing let it be the first user

            Console.WriteLine("Welcome to Musical Collection App!");

            commandHandler.PrintHelp();

            while (true)
            {
                try
                {
                    Console.Write("> ");
                    var input = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(input) || input.ToLower() == "exit")
                        break;

                    commandHandler.HandleCommand(input);
                }
                catch (Exception ex) 
                {
                    UI.PrintErrorMessage($"Error: {ex.Message}");
                }
            }
        }
    }
}