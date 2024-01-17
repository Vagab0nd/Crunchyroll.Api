using Crunchyroll.Api.Infrastructure.Extensions;
using System.Text.Json;

namespace Crunchyroll.Api.Infrastructure
{
    internal sealed class JsonSnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return name.ToSnakeCase();
        }
    }
}
