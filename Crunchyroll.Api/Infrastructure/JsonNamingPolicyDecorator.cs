using System.Text.Json;

namespace Crunchyroll.Api.Infrastructure
{
    internal class JsonNamingPolicyDecorator(JsonNamingPolicy underlyingNamingPolicy) : JsonNamingPolicy
    {
        readonly JsonNamingPolicy underlyingNamingPolicy = underlyingNamingPolicy;

        public override string ConvertName(string name) => this.underlyingNamingPolicy?.ConvertName(name) ?? name;
    }
}
