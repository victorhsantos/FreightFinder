using System;
using System.Collections.Generic;
using BuildingBlocks.Logger.Enums;
using BuildingBlocks.Logger.Models;


namespace BuildingBlocks.Logger.Services.Interfaces
{
    public interface IWriteLogger
    {
        void Logger(
            BBLogLevel logLevel,
            Exception exception,            
            string messageTemplate,
            IEnumerable<ParametersLogModel> parameters = null,
            string flow = null);
    }
}
