using System;
using System.IO;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Everhour.Net.Tests
{
    public abstract class FactBase
    {
        protected Mock<EverhourClient> MockApi { get; set; }

        public FactBase()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            
            var apiKey = config.GetSection("Everhour:ApiKey").Value;
            MockApi = new Mock<EverhourClient>(apiKey, null, null) { CallBase = true };

            Initialize();
        }

        protected virtual void Initialize() { }

        protected virtual HttpResponseMessage GenerateMockResponse(string mockContent = null)
        { 
            var response =  new HttpResponseMessage(HttpStatusCode.OK);
            if (!string.IsNullOrEmpty(mockContent)) response.Content = new StringContent(mockContent);
            return response;
        }
    }
}