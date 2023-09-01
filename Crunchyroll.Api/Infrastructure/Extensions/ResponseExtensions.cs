using Crunchyroll.Api.Models.Response;
using System.Threading.Tasks;

namespace Crunchyroll.Api.Infrastructure.Extensions
{
    internal static class ResponseExtensions
    {
        public static async Task<T> UnpackResponse<T>(this Task<Response<T>> responseTask)
        {
            var response = await responseTask;
            return response.Data;
        }
    }
}
