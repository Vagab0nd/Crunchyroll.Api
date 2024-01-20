using System.Text.Json;

namespace Crunchyroll.Api.Infrastructure
{
    public class JsonNamingPolicyDecorator : JsonNamingPolicy
    {
        readonly JsonNamingPolicy underlyingNamingPolicy;

        public JsonNamingPolicyDecorator(JsonNamingPolicy underlyingNamingPolicy) => this.underlyingNamingPolicy = underlyingNamingPolicy;
        public override string ConvertName(string name) => this.underlyingNamingPolicy?.ConvertName(name) ?? name;
    }
}
