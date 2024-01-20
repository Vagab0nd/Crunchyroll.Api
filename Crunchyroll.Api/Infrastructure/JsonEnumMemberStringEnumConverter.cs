using System;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Linq;
using System.Runtime.Serialization;

namespace Crunchyroll.Api.Infrastructure
{
    internal sealed class JsonEnumMemberStringEnumConverter : JsonConverterFactory
    {
        private readonly JsonNamingPolicy namingPolicy;
        private readonly bool allowIntegerValues;
        private readonly JsonStringEnumConverter baseConverter;

        public JsonEnumMemberStringEnumConverter() : this(null, true) { }

        public JsonEnumMemberStringEnumConverter(JsonNamingPolicy namingPolicy = null, bool allowIntegerValues = true)
        {
            this.namingPolicy = namingPolicy;
            this.allowIntegerValues = allowIntegerValues;
            this.baseConverter = new JsonStringEnumConverter(namingPolicy, allowIntegerValues);
        }

        public override bool CanConvert(Type typeToConvert) => this.baseConverter.CanConvert(typeToConvert);

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var query = from field in typeToConvert.GetFields(BindingFlags.Public | BindingFlags.Static)
                        let attr = field.GetCustomAttribute<EnumMemberAttribute>()
                        where attr != null && attr.Value != null
                        select (field.Name, attr.Value);
            var dictionary = query.ToDictionary(p => p.Name, p => p.Value);
            if (dictionary.Count > 0)
            {
                return new JsonStringEnumConverter(new DictionaryLookupNamingPolicy(dictionary, this.namingPolicy), this.allowIntegerValues).CreateConverter(typeToConvert, options);
            }
            else
            {
                return this.baseConverter.CreateConverter(typeToConvert, options);
            }
        }
    }
}
