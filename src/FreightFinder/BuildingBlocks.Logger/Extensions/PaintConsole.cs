using BuildingBlocks.Logger.Enums;
using BuildingBlocks.Logger.Extensions.Interfaces;
using System;

namespace BuildingBlocks.Logger.Extensions
{
    internal class PaintConsole: IPaintConsole
    {
        public void PrintConsole(BBLogLevel logLevel)
        {
            Console.BackgroundColor = ConsoleColor.Black;

            switch (logLevel)
            {
                case BBLogLevel.Verbose:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case BBLogLevel.Debug:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case BBLogLevel.Information:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case BBLogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case BBLogLevel.Error:
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    }
                case BBLogLevel.Fatal:
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    }
            }

            Console.WriteLine($"===================================== ({logLevel}) =====================================");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void PrintWelcome(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('=', text.Length + 4));
            Console.WriteLine($"| {text} |");
            Console.WriteLine(new string('=', text.Length + 4));
        }
    }
}
