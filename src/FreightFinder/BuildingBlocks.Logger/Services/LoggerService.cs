using BuildingBlocks.Logger.Enums;
using BuildingBlocks.Logger.Models;
using BuildingBlocks.Logger.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace BuildingBlocks.Logger.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly IWriteLogger _logger;

        public LoggerService(IWriteLogger logger)
        {
            _logger = logger;
        }

        public void Log(BBLogLevel logLevel, string messageTemplate, IEnumerable<ParametersLogModel> propertyValues = null, string flow = null) =>
            _logger.Logger(logLevel, exception: null, messageTemplate, propertyValues, flow);


        public void Log(BBLogLevel logLevel, Exception exception, string messageTemplate, IEnumerable<ParametersLogModel> propertyValues = null, string flow = null) =>
            _logger.Logger(logLevel, exception, messageTemplate, propertyValues, flow);

    }
}
