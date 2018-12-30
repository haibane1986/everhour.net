using System;
using System.Text;
using System.Net.Http;
using System.Net.Mime;
using Newtonsoft.Json;

namespace Everhour.Net
{
    public partial class EverhourClient
    {
        private HttpRequestMessage ListRequest(string resource) => Request(resource);

        private HttpRequestMessage Request(string resource, HttpMethod method = null)
        {             
             var request =  new HttpRequestMessage(method ?? HttpMethod.Get, resource);
             request.Headers.Add("X-Api-Key", _apiKey);
             request.Headers.Add("X-Accept-Version", _apiVersion);

             return request;
        }

        private HttpRequestMessage Request(string resource, int resourceId, string actionOrSubresource, HttpMethod method)
        {
            if (string.IsNullOrWhiteSpace(actionOrSubresource))
                throw new ArgumentException("Value cannot be null or empty.", nameof(actionOrSubresource));
            
            return Request(resource, resourceId.ToString(), actionOrSubresource, method);
        }

        private HttpRequestMessage Request(string resource, string resourceId, string actionOrSubresource, HttpMethod method)
        {
            if (string.IsNullOrWhiteSpace(resource))
                throw new ArgumentException("Value cannot be null or empty.", nameof(resource));
                
            if (string.IsNullOrWhiteSpace(resourceId))
                throw new ArgumentException("Value cannot be null or empty.", nameof(resourceId));

            if (string.IsNullOrWhiteSpace(actionOrSubresource))
                throw new ArgumentException("Value cannot be null or empty.", nameof(actionOrSubresource));

            var resourceUrl = $"{resource}/{resourceId}/{actionOrSubresource}";
            
            return Request(resourceUrl, method);
        }

        private HttpRequestMessage Request(string resource, string resourceId, HttpMethod method)
        {
            if (string.IsNullOrWhiteSpace(resource))
                throw new ArgumentException("Value cannot be null or empty.", nameof(resource));
            
            if (string.IsNullOrWhiteSpace(resourceId))
                throw new ArgumentException("Value cannot be null or empty.", nameof(resourceId));

            var resourceUrl = $"{resource}/{resourceId}";

            return Request(resourceUrl, method);
        }

        private HttpRequestMessage Request(string resource, int resourceId, HttpMethod method)
        {
            if (string.IsNullOrWhiteSpace(resource))
                throw new ArgumentException("Value cannot be null or empty.", nameof(resource));

            return Request(resource, resourceId.ToString(), method);
        }
        
        private HttpRequestMessage CreateRequest<TOptions>(string resource, TOptions options)
            where TOptions : class, new()
        {
            if (string.IsNullOrWhiteSpace(resource))
                throw new ArgumentException("Value cannot be null or empty.", nameof(resource));

            var request = Request(resource, HttpMethod.Post);
            var json = JsonConvert.SerializeObject(options, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, DateFormatString = "yyyy-MM-dd HH:mm:ss" } );
            request.Content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
            return request;
        }

        private HttpRequestMessage CreateRequest<TOptions>(string resource, int resourceId, string subresource, TOptions options)
            where TOptions : class, new()
        {
            if (string.IsNullOrWhiteSpace(resource))
                throw new ArgumentException("Value cannot be null or empty.", nameof(resource));
            
            if (string.IsNullOrWhiteSpace(subresource))
                throw new ArgumentException("Value cannot be null or empty.", nameof(subresource));

            return CreateRequest<TOptions>(resource, resourceId.ToString(), subresource, options);
        }

        private HttpRequestMessage CreateRequest<TOptions>(string resource, string resourceId, string subresource, TOptions options)
            where TOptions : class, new()
        {
            if (string.IsNullOrWhiteSpace(resource))
                throw new ArgumentException("Value cannot be null or empty.", nameof(resource));
            
            if (string.IsNullOrWhiteSpace(resourceId))
                throw new ArgumentException("Value cannot be null or empty.", nameof(resourceId));
            
            if (string.IsNullOrWhiteSpace(subresource))
                throw new ArgumentException("Value cannot be null or empty.", nameof(subresource));

            var request =  Request(resource, resourceId, subresource, HttpMethod.Post);
            var json = JsonConvert.SerializeObject(options, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, DateFormatString = "yyyy-MM-dd HH:mm:ss" });
            request.Content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
            return request;
        }

        private HttpRequestMessage UpdateRequest<TOptions>(string resource, int resourceId, TOptions options)
            where TOptions : class, new()
        {
            if (string.IsNullOrWhiteSpace(resource))
                throw new ArgumentException("Value cannot be null or empty.", nameof(resource));
            
            return UpdateRequest<TOptions>(resource, resourceId.ToString(), options);
        }

        private HttpRequestMessage UpdateRequest<TOptions>(string resource, string resourceId, TOptions options)
            where TOptions : class, new()
        {
            if (string.IsNullOrWhiteSpace(resource))
                throw new ArgumentException("Value cannot be null or empty.", nameof(resource));

            if (string.IsNullOrWhiteSpace(resourceId))
                throw new ArgumentException("Value cannot be null or empty.", nameof(resourceId));

            var request =  Request(resource, resourceId, HttpMethod.Put);
            var json = JsonConvert.SerializeObject(options, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, DateFormatString = "yyyy-MM-dd HH:mm:ss" });
            request.Content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
            return request;
        }

        private HttpRequestMessage UpdateRequest<TOptions>(string resource, int resourceId, string subresource, TOptions options)
            where TOptions : class, new()
        {
            if (string.IsNullOrWhiteSpace(resource))
                throw new ArgumentException("Value cannot be null or empty.", nameof(resource));

            if (string.IsNullOrWhiteSpace(subresource))
                throw new ArgumentException("Value cannot be null or empty.", nameof(subresource));
        
            return UpdateRequest<TOptions>(resource, resourceId.ToString(), subresource, options);
        }

        private HttpRequestMessage UpdateRequest<TOptions>(string resource, string resourceId, string subresource, TOptions options)
            where TOptions : class, new()
        {
            if (string.IsNullOrWhiteSpace(resource))
                throw new ArgumentException("Value cannot be null or empty.", nameof(resource));

            if (string.IsNullOrWhiteSpace(resourceId))
                throw new ArgumentException("Value cannot be null or empty.", nameof(resourceId));

            if (string.IsNullOrWhiteSpace(subresource))
                throw new ArgumentException("Value cannot be null or empty.", nameof(subresource));
        
            var request =  Request(resource, resourceId, subresource, HttpMethod.Put);
            var json = JsonConvert.SerializeObject(options, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, DateFormatString = "yyyy-MM-dd HH:mm:ss" });
            request.Content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
            return request;
        }

        private HttpRequestMessage DeleteRequest<TOptions>(string resource, string resourceId, string subresource, TOptions options)
            where TOptions : class, new()
        {
            if (string.IsNullOrWhiteSpace(resource))
                throw new ArgumentException("Value cannot be null or empty.", nameof(resource));

            if (string.IsNullOrWhiteSpace(resourceId))
                throw new ArgumentException("Value cannot be null or empty.", nameof(resourceId));

            if (string.IsNullOrWhiteSpace(subresource))
                throw new ArgumentException("Value cannot be null or empty.", nameof(subresource));
        
            var request =  Request(resource, resourceId, subresource, HttpMethod.Delete);
            var json = JsonConvert.SerializeObject(options, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, DateFormatString = "yyyy-MM-dd HH:mm:ss" });
            request.Content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
            return request;
        }

        private HttpRequestMessage DeleteRequest(string resource)
        {
            if (string.IsNullOrWhiteSpace(resource))
                throw new ArgumentException("Value cannot be null or empty.", nameof(resource));
        
            return Request(resource, HttpMethod.Delete);
        }
    }
}
