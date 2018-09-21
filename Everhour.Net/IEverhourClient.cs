using System.Net.Http;
using System.Threading.Tasks;
using Everhour.Net.Models;

namespace Everhour.Net
{
    internal partial interface IEverhourClient
    {
        string BaseUrl { get; }

        Task<T> ExecuteAsync<T>(HttpRequestMessage request)
            where T : EverhourResponse<T>, new();
        
        Task<HttpResponseMessage> ExecuteAsync(HttpRequestMessage request);
    }
}