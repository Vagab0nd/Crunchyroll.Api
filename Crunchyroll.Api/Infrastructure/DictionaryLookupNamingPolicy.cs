using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Crunchyroll.Api.Infrastructure
{
    internal sealed class DictionaryLookupNamingPolicy : JsonNamingPolicyDecorator
    {
        readonly Dictionary<string, string> dictionary;

        public DictionaryLookupNamingPolicy(Dictionary<string, string> dictionary, JsonNamingPolicy underlyingNamingPolicy) : base(underlyingNamingPolicy) => this.dictionary = dictionary ?? throw new ArgumentNullException();

        public override string ConvertName(string name) => this.dictionary.TryGetValue(name, out var value) ? value : base.ConvertName(name);
    }
}
