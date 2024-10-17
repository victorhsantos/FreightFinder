using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Logger.Configurations
{
    public static class BuildingBlocksLogger
    {
        public static BBLoggerConfiguration AddBuildinBlocksLogging(this IServiceCollection services) =>
            new BBLoggerConfiguration(services);
    }
}
