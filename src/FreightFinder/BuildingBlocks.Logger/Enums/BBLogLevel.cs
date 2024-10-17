using Serilog.Events;

namespace BuildingBlocks.Logger.Enums
{
    public enum BBLogLevel
    {
        Verbose = LogEventLevel.Verbose,
        Debug = LogEventLevel.Debug,
        Information = LogEventLevel.Information,
        Warning = LogEventLevel.Warning,
        Error = LogEventLevel.Error,
        Fatal = LogEventLevel.Fatal
    }
}
