using System;
using Serilog;
using System.Collections.Generic;
using BuildingBlocks.Logger.Enums;
using BuildingBlocks.Logger.Models;
using BuildingBlocks.Logger.Services.Interfaces;
using BuildingBlocks.Logger.Extensions.Interfaces;
using BuildingBlocks.Logger.Configurations;
using Newtonsoft.Json;
using Serilog.Events;

namespace BuildingBlocks.Logger.Services
{
    public class WriteLogger : IWriteLogger
    {

        private ILogger _logger;
        private readonly IObfuscateSensitiveData _obfuscateSensitiveDate;
        private readonly bool _useObfuscateSensitiveDate;

        public WriteLogger(
            ILogger logger,
            IObfuscateSensitiveData obfuscateSensitiveDate,
            bool useObfuscateSensitiveDate = false)
        {
            _logger = logger;
            _obfuscateSensitiveDate = obfuscateSensitiveDate;
            _useObfuscateSensitiveDate = useObfuscateSensitiveDate;
        }

        public void Logger(
            BBLogLevel logLevel,
            Exception exception,
            string messageTemplate,
            IEnumerable<ParametersLogModel> parameters = null,
            string flow = null)
        {
            object[] propertyValues = _obfuscateSensitiveDate.Blur(parameters, _useObfuscateSensitiveDate);

            var message = new LogJsonDataModel
            {
                Flow = flow,
                Exception = exception,
                Message = propertyValues is null ? messageTemplate : String.Format(messageTemplate, propertyValues),
                Timestamp = DateTime.Now
            };

            _logger.Write((LogEventLevel)logLevel, JsonConvert.SerializeObject(message));
        }
    }
}
