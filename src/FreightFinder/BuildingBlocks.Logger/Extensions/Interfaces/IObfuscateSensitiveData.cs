using BuildingBlocks.Logger.Enums;
using BuildingBlocks.Logger.Models;
using System.Collections.Generic;

namespace BuildingBlocks.Logger.Extensions.Interfaces
{
    public interface IObfuscateSensitiveData
    {
        object[] Blur(IEnumerable<ParametersLogModel> parameters, bool applyObfuscate = true);
        object Blur(object data, ObfuscateTypeForSensitiveData obfuscateTypeForSensitiveData);
    }
}
