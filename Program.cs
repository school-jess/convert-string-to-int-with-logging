// See https://aka.ms/new-console-template for more information
using Serilog;

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
            logger.Information("started application");
            bool wantToExit = false;
            while (!wantToExit)
            {
                Console.Clear();
                Console.Write("Enter a number: ");
                try
                {
                    int num = Convert.ToInt32(Console.ReadLine());
                    logger.Information("succesful given int");
                    Console.WriteLine($"Inputted number is {num}");
                }
                catch
                {
                    logger.Error("got error");
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
            logger.Information("Ended application");
            logger.Dispose();
        }
    }
}
