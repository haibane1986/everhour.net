using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Everhour.Net.Models;

namespace Everhour.Net
{
    public partial class EverhourClient : IEverhourClient
    {
        public string BaseUrl { get; private set; }
        
        private readonly string _apiKey;
        private readonly string _apiVersion;
        private static HttpClient _client;

        public EverhourClient(string apiKey, string apiVersion = null, HttpClientHandler httpClientHandler = null)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _apiVersion = apiVersion ?? "1.2";
            BaseUrl = "https://api.everhour.com/";

            var handler = new HttpClientHandler() { UseCookies = false };
            _client = new HttpClient(httpClientHandler ?? handler) { BaseAddress = new Uri(BaseUrl)};
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
        }

        public virtual async Task<T> ExecuteAsync<T>(HttpRequestMessage request) where T: EverhourResponse<T>, new ()
        {
            var response = await ExecuteAsync(request).ConfigureAwait(false);
            var t = new T().FromJson(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            t.StatusCode = (int)response.StatusCode;
            return t;
        }

        public virtual async Task<HttpResponseMessage> ExecuteAsync(HttpRequestMessage request)
        {
            var response = await _client.SendAsync(request).ConfigureAwait(false);
            await response.ThrowIfBadRequest();
            return response;
        }
    }
}