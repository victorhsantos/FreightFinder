using BuildingBlocks.Logger.Enums;

namespace BuildingBlocks.Logger.Models
{
    public class ParametersLogModel
    {
        public object Value { get; private set; }
        public ObfuscateTypeForSensitiveData ObfuscateType { get; private set; }

        public ParametersLogModel(object value, ObfuscateTypeForSensitiveData obfuscateType = ObfuscateTypeForSensitiveData.None)
        {
            ObfuscateType = obfuscateType;
            Value = value;
        }
    }
}
