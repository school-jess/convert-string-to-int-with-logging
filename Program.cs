// See https://aka.ms/new-console-template for more information
using Serilog;
using System;

namespace ConvuserInputToInt
{
    class Program
    {
        static void Main()
        {
            var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logs.txt", outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
            logger.Debug("started application");
            bool wantToExit = false;
            while (!wantToExit)
            {
                Console.Clear();
                Console.Write("Enter a number: ");
                try
                {
                    int num = Convert.ToInt32(Console.ReadLine());
                    logger.Information($"succesful given int: {num}");
                    Console.WriteLine($"Inputted number is {num}");
                }
                catch (FormatException)
                {
                    logger.Error("input was a character");
                    Console.WriteLine("Pls. input a number");
                } catch (OverflowException) {
                    logger.Error("input was too big.");
                    Console.WriteLine("input was to big");
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
            logger.Debug("Ended application");
            logger.Dispose();
        }
    }
}
