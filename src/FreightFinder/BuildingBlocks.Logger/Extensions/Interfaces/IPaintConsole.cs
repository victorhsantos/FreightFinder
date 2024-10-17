using BuildingBlocks.Logger.Enums;

namespace BuildingBlocks.Logger.Extensions.Interfaces
{
    public interface IPaintConsole
    {
        void PrintWelcome(string text);
        void PrintConsole(BBLogLevel logLevel);
    }
}
