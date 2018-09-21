using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Everhour.Net.Tests.ResourceFacts
{
    public class ClientsFact : FactBase
    {
        [Fact]
        public async Task ListAllClientsAsync_ReturnsClients()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.LIST_CLIENTS)));
            var res = await MockApi.Object.ListAllClientsAsync();

            Assert.NotNull(res);
            Assert.All(res.Clients, c => Assert.NotEqual(default(int), c.Id));
            Assert.All(res.Clients, c => Assert.NotNull(c.Name));
            Assert.All(res.Clients, c => Assert.NotNull(c.Projects));
            Assert.All(res.Clients, c => Assert.NotNull(c.BusinessDetails));
            Assert.All(res.Clients, c => Assert.NotEqual(default(int), c.Budget.Value));
            Assert.All(res.Clients, c => Assert.NotEqual(default(int), c.Budget.Progress));
            Assert.All(res.Clients, c => Assert.Equal(Models.BudgetType.MONEY, c.Budget.Type));
        }

        [Fact]
        public async Task CreateClientAsync_ReturnsClient()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.CREATE_CLIENT)));
            var res = await MockApi.Object.CreateClientAsync("Test Cleint");

            Assert.NotNull(res);
            Assert.NotEqual(default(int), res.Client.Id);
            Assert.NotNull(res.Client.Name);
            Assert.NotNull(res.Client.Projects);
            Assert.NotNull(res.Client.BusinessDetails);
            Assert.NotEqual(default(int), res.Client.Budget.Value);
            Assert.NotEqual(default(int), res.Client.Budget.Progress);
            Assert.Equal(Models.BudgetType.MONEY, res.Client.Budget.Type);
        }

        [Fact]
        public async Task CreateClientAsyncWithRequest_ReturnsClient()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.CREATE_CLIENT)));

            var req = new Models.CreateClientRequest()
            {
                Name = "Test Client",
                Projects = new List<string>() { "Test Project" },
                BusinessDetails = "Business Details"
            };
            var res = await MockApi.Object.CreateClientAsync(req);

            Assert.NotNull(res);
            Assert.NotEqual(default(int), res.Client.Id);
            Assert.NotNull(res.Client.Name);
            Assert.NotNull(res.Client.Projects);
            Assert.NotNull(res.Client.BusinessDetails);
            Assert.NotEqual(default(int), res.Client.Budget.Value);
            Assert.NotEqual(default(int), res.Client.Budget.Progress);
            Assert.Equal(Models.BudgetType.MONEY, res.Client.Budget.Type);
        }
        
        [Fact]
        public async Task RetrieveClientAsync_ReturnsClient()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.RETRIEVE_CLIENT)));

            var res = await MockApi.Object.RetrieveClientAsync(1234);

            Assert.NotNull(res);
            Assert.NotEqual(default(int), res.Client.Id);
            Assert.NotNull(res.Client.Name);
            Assert.NotNull(res.Client.Projects);
            Assert.NotNull(res.Client.BusinessDetails);
            Assert.NotEqual(default(int), res.Client.Budget.Value);
            Assert.NotEqual(default(int), res.Client.Budget.Progress);
            Assert.Equal(Models.BudgetType.MONEY, res.Client.Budget.Type);
        }

        [Fact]
        public async Task UpdateClientAsync_ReturnsClient()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.UPDATE_CLIENT)));

            var res = await MockApi.Object.UpdateClientAsync(1234, "Test Client");

            Assert.NotNull(res);
            Assert.NotEqual(default(int), res.Client.Id);
            Assert.NotNull(res.Client.Name);
            Assert.NotNull(res.Client.Projects);
            Assert.NotNull(res.Client.BusinessDetails);
            Assert.NotEqual(default(int), res.Client.Budget.Value);
            Assert.NotEqual(default(int), res.Client.Budget.Progress);
            Assert.Equal(Models.BudgetType.MONEY, res.Client.Budget.Type);
        }

        [Fact]
        public async Task UpdateClientAsyncWithRequest_ReturnsClient()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.UPDATE_CLIENT)));

            var req = new Models.UpdateClientRequest()
            {
                Id = 1234,
                Name = "Test Client",
                Projects = new List<string>() { "Test Project" },
                BusinessDetails = "Business Details"
            };
            var res = await MockApi.Object.UpdateClientAsync(req);

            Assert.NotNull(res);
            Assert.NotEqual(default(int), res.Client.Id);
            Assert.NotNull(res.Client.Name);
            Assert.NotNull(res.Client.Projects);
            Assert.NotNull(res.Client.BusinessDetails);
            Assert.NotEqual(default(int), res.Client.Budget.Value);
            Assert.NotEqual(default(int), res.Client.Budget.Progress);
            Assert.Equal(Models.BudgetType.MONEY, res.Client.Budget.Type);
        }

        [Fact]
        public async Task SetClientBudgetAsync_ReturnsClient()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.SET_CLIENT_BUDGET)));

            var res = await MockApi.Object.SetClientBudgetAsync(1234, Models.BudgetType.MONEY, 10000);

            Assert.NotNull(res);
            Assert.NotEqual(default(int), res.Client.Id);
            Assert.NotNull(res.Client.Name);
            Assert.NotNull(res.Client.Projects);
            Assert.NotNull(res.Client.BusinessDetails);
            Assert.NotEqual(default(int), res.Client.Budget.Value);
            Assert.NotEqual(default(int), res.Client.Budget.Progress);
            Assert.Equal(Models.BudgetType.MONEY, res.Client.Budget.Type);
        }

        [Fact]
        public async Task DeleteClientBudgetAsync_ReturnsIsSuucessful()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse()));

            var res = await MockApi.Object.DeleteClientBudgetAsync(1234);

            Assert.True(res);
        }
    }
}