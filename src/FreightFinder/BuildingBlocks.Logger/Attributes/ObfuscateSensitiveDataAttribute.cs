using System;
using BuildingBlocks.Logger.Enums;

namespace Localiza.BuildingBlocks.Logging.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class ObfuscateSensitiveDataAttribute : Attribute
    {
        private readonly ObfuscateTypeForSensitiveData obfuscateTypeForSensitiveData;

        public ObfuscateSensitiveDataAttribute(ObfuscateTypeForSensitiveData obfuscateTypeForSensitiveData)
        {
            this.obfuscateTypeForSensitiveData = obfuscateTypeForSensitiveData;
        }

        public virtual ObfuscateTypeForSensitiveData ObfuscateType
        {
            get { return obfuscateTypeForSensitiveData; }
        }
    }
}
