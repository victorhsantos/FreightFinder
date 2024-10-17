using BuildingBlocks.Logger.Configurations;
using BuildingBlocks.Logger.Enums;
using BuildingBlocks.Logger.Extensions.Interfaces;
using BuildingBlocks.Logger.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Localiza.BuildingBlocks.Logging.Attributes;

namespace BuildingBlocks.Logger.Extensions
{
    public class ObfuscateSensitiveData : IObfuscateSensitiveData
    {
        public object[] Blur(IEnumerable<ParametersLogModel> parameters, bool applyObfuscate = true)
        {
            object[] propertyValues = null;

            if (parameters != null)
            {
                if (parameters.Any())
                {
                    propertyValues = new object[parameters.ToList().Count];

                    int i = 0;

                    foreach (var item in parameters)
                    {
                        propertyValues[i] = BlurSensitiveData(item, applyObfuscate);
                        i++;
                    }
                }
            }

            return propertyValues;
        }
        public object Blur(object data, ObfuscateTypeForSensitiveData obfuscateTypeForSensitiveData) =>
            BlurSensitiveData(new ParametersLogModel(data, obfuscateTypeForSensitiveData));

        #region Private Methods

        private object BlurSensitiveData(ParametersLogModel data, bool applyObfuscate = true)
        {
            if (!applyObfuscate) return data.Value;

            object bluredData = data.Value;
            string dataString = data.Value.ToString();

            try
            {
                switch (data.ObfuscateType)
                {
                    case ObfuscateTypeForSensitiveData.Half:
                        bluredData = HalfBlur(dataString); break;

                    case ObfuscateTypeForSensitiveData.Complete:
                        bluredData = CompleteBlur(dataString); break;

                    case ObfuscateTypeForSensitiveData.Name:
                        bluredData = BlurAtName(dataString); break;

                    case ObfuscateTypeForSensitiveData.Address:
                        bluredData = IntercaledBlur(dataString);
                        break;

                    case ObfuscateTypeForSensitiveData.PersonalIdentity:
                        bluredData = dataString; break;

                    case ObfuscateTypeForSensitiveData.Email:
                        bluredData = BlurAtEmail(dataString); break;

                    case ObfuscateTypeForSensitiveData.JsonFromClass:
                        bluredData = ConvertClassToJson(bluredData, applyObfuscate);
                        break;
                }
            }
            catch
            {
                bluredData = CompleteBlur(dataString);
            }

            return bluredData;
        }

        private string BlurAtEmail(string value)
        {
            int positionChar = value.IndexOf("@") - 1;
            return value.Substring(0, 1) +
                new string(Constants.OBFUSCATE_CHAR_FOR_STRING_FIELDS, positionChar) + value.Substring(positionChar);
        }

        private string BlurAtName(string value)
        {
            string[] part = value.Split(" ");
            string bluredData = part[0];

            for (int i = 1; i < part.Length; i++)
                bluredData += " " + new string(Constants.OBFUSCATE_CHAR_FOR_STRING_FIELDS, part[i].Length);

            return bluredData;
        }

        private string HalfBlur(string value)
        {
            return new string(
                Constants.OBFUSCATE_CHAR_FOR_STRING_FIELDS, value.Length / 2) +
                value.Substring(value.Length / 2);
        }

        private string CompleteBlur(string value)
        {
            return new string(Constants.OBFUSCATE_CHAR_FOR_STRING_FIELDS, value.Length);
        }

        private string IntercaledBlur(string value)
        {
            string bluredData = string.Empty;
            string[] part = value.Split(" ");
            bool aux = false;
            for (int i = 0; i < part.Length; i++)
            {
                if (!aux)
                {
                    bluredData += part[i];
                    aux = true;
                }
                else
                {
                    bluredData += new string(Constants.OBFUSCATE_CHAR_FOR_STRING_FIELDS, part[i].Length);
                    aux = false;
                }
            }
            return bluredData;
        }

        private object ConvertClassToJson(object value, bool applyObfuscate = true)
        {
            if (!applyObfuscate) return JsonConvert.SerializeObject(value);

            var propertiesValues = (PropertyInfo[])((TypeInfo)value.GetType()).DeclaredProperties;

            int i = 0;
            foreach (var item in value.GetType().GetProperties())
            {
                var obfuscateTypeForSensitiveData = GetCustomAttribute(item);

                if (IsObjectClass(item)) //class
                {
                    BlurObjectClass(item, ref value);
                }
                else //property
                {
                    var jsonPropertyValue = propertiesValues[i].GetValue(value);
                    var obfuscatedValue = Blur(jsonPropertyValue, obfuscateTypeForSensitiveData);
                    if (item.CanWrite)
                        item.SetValue(value, obfuscatedValue);
                }

                i++;
            }

            return value;
        }

        private void BlurObjectClass(PropertyInfo propertyInfo, ref object value)
        {
            var fieldsValues = propertyInfo.GetValue(value);

            foreach (var item in fieldsValues.GetType().GetProperties())
            {
                if (IsObjectClass(item))
                {
                    BlurObjectClass(item, ref fieldsValues);
                }
                else
                {
                    var obfuscateTypeForSensitiveData = GetCustomAttribute(item);
                    var jsonPropertyValue = item.GetValue(fieldsValues);
                    var obfuscatedValue = Blur(jsonPropertyValue, obfuscateTypeForSensitiveData);
                    item.SetValue(fieldsValues, obfuscatedValue);
                }
            }
        }

        private bool IsObjectClass(PropertyInfo propertyInfo)
        {
            return (propertyInfo.PropertyType.IsNested || !propertyInfo.PropertyType.IsSealed);
        }

        private ObfuscateTypeForSensitiveData GetCustomAttribute(PropertyInfo propertyInfo)
        {
            var obfuscateTypeForSensitiveData = ObfuscateTypeForSensitiveData.None;

            var customAttribute = propertyInfo.CustomAttributes.ToList();

            if (customAttribute.Any())
            {
                var attr = customAttribute
                    .Where(x => x.AttributeType.Name == typeof(ObfuscateSensitiveDataAttribute).Name);

                if (attr.Any())
                {
                    obfuscateTypeForSensitiveData = (ObfuscateTypeForSensitiveData)attr.FirstOrDefault().ConstructorArguments.FirstOrDefault().Value;
                }
            }

            return obfuscateTypeForSensitiveData;
        }

        #endregion

    }
}
