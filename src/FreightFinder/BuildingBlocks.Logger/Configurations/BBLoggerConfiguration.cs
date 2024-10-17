using Serilog;
using BuildingBlocks.Logger.Extensions;
using BuildingBlocks.Logger.Services;
using BuildingBlocks.Logger.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Core;
using Serilog.Events;
using System.Collections.Generic;
using BuildingBlocks.Logger.Enums;

namespace BuildingBlocks.Logger.Configurations
{
    public class BBLoggerConfiguration
    {
        private readonly LoggerConfiguration loggerConfig = new LoggerConfiguration();
        private readonly ObfuscateSensitiveData obfuscateSensitiveDate = new ObfuscateSensitiveData();
        private bool useObfuscateSensitiveDate = false;

        public IServiceCollection Services { get; }

        public BBLoggerConfiguration(IServiceCollection services)
        {
            Services = services;
            Services.AddSingleton(this);
            services.AddScoped<ILoggerService, LoggerService>();
            Services.AddSingleton<IWriteLogger>(delegate
            {
                return new WriteLogger(
                    loggerConfig.CreateLogger(),
                    obfuscateSensitiveDate,
                    useObfuscateSensitiveDate
                    );
            });
        }

        public BBLoggerConfiguration AddTags(Dictionary<string, object> tagLists)
        {
            foreach (var item in tagLists)
                loggerConfig.Enrich.WithProperty(item.Key, item.Value);

            return this;
        }

        public BBLoggerConfiguration SetLogLevel(BBLogLevel logLevel = BBLogLevel.Information)
        {
            var _loggingLevel = new LoggingLevelSwitch((LogEventLevel)logLevel);
            loggerConfig.MinimumLevel.ControlledBy(_loggingLevel);
            return this;
        }

        public BBLoggerConfiguration WithConsoleOutput()
        {
            loggerConfig.WriteTo.Console(outputTemplate: "[{Level:u3}] {Message:lj}{NewLine}");
            return this;
        }

        public BBLoggerConfiguration WithFileOutput()
        {
            loggerConfig.WriteTo.File("Log\\log.txt", outputTemplate: "[{Level:u3}] {Message:lj}{NewLine}");
            return this;
        }

        public BBLoggerConfiguration UseObfuscateSensiteData()
        {
            useObfuscateSensitiveDate = true;
            return this;
        }
    }
}
