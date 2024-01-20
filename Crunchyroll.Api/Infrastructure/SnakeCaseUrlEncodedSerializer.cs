using Crunchyroll.Api.Infrastructure.Extensions;
using Flurl;
using Flurl.Http.Configuration;
using Flurl.Util;
using System;
using System.IO;

namespace Crunchyroll.Api.Infrastructure
{
    internal sealed class SnakeCaseUrlEncodedSerializer(bool serializeEnumValueLowercase = false) : ISerializer
    {
        private readonly bool serializeEnumValueLowercase = serializeEnumValueLowercase;

        /// <summary>
        /// Serializes the specified object. Based on DefaultUrlEncodedSerializer.
        /// </summary>
        /// <param name="obj">The object.</param>
        public string Serialize(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            var qp = new QueryParamCollection();
            foreach (var (Key, Value) in obj.ToKeyValuePairs())
            {
                var formattedValue = Value?.ToString();
                if(this.serializeEnumValueLowercase && Value?.GetType().IsEnum == true)
                {
                    formattedValue = formattedValue.ToLowerInvariant();
                }
                qp.AddOrReplace(Key.ToSnakeCase(), formattedValue, false, NullValueHandling.Ignore);
            }
            return qp.ToString(true);
        }

        /// <summary>
        /// Deserializes the specified s.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s">The s.</param>
        /// <exception cref="NotImplementedException">Deserializing to UrlEncoded not supported.</exception>
        public T Deserialize<T>(string s)
        {
            throw new NotImplementedException("Deserializing to UrlEncoded is not supported.");
        }

        /// <summary>
        /// Deserializes the specified stream.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream">The stream.</param>
        /// <exception cref="NotImplementedException">Deserializing to UrlEncoded not supported.</exception>
        public T Deserialize<T>(Stream stream)
        {
            throw new NotImplementedException("Deserializing to UrlEncoded is not supported.");
        }
    }
}
