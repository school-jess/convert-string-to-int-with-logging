// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Logging;

namespace ConvuserInputToInt
{
    class Program
    {
        static void Main()
        {
            using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger logger = factory.CreateLogger("Program");
            logger.LogInformation("Hello world! Logging is {Description}.", "fun");
            bool wantToExit = false;
            while (!wantToExit)
            {
                Console.Clear();
                Console.Write("Enter a number: ");
                try
                {
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Inputted number is {num}");
                }
                catch
                {
                    Console.WriteLine("Pls. input a number");
                }
                ConsoleKey tryAgain = ConsoleKey.A;
                while (tryAgain != ConsoleKey.Y || tryAgain != ConsoleKey.N)
                {
                    Console.Write("continue... ");
                    tryAgain = Console.ReadKey().Key;
                    if (tryAgain == ConsoleKey.N)
                    {
                        wantToExit = true;
                        break;
                    }
                    if (tryAgain == ConsoleKey.Y)
                    {
                        break;
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Goodbye!");
        }
    }
}
