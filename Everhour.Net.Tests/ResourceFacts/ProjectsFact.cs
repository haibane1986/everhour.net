using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Everhour.Net.Tests.ResourceFacts
{
    public class ProjectsFact : FactBase
    {
        [Fact]
        public async Task ListAllCProjectsAsync_ReturnsProjects()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.LIST_ALL_PROJECTS)));
            var res = await MockApi.Object.ListAllProjectsAsync();

            Assert.NotNull(res);
            Assert.All(res.Projects, p => Assert.NotNull(p.Id));
            Assert.All(res.Projects, p => Assert.NotNull(p.Name));
            Assert.All(res.Projects, p => Assert.NotNull(p.WorkspaceId));
            Assert.All(res.Projects, p => Assert.NotNull(p.Workspace));
            Assert.All(res.Projects, p => Assert.Equal(Models.ProjectType.BOARD, p.Type));
            Assert.All(res.Projects, p => Assert.True(p.Favorite));
            Assert.All(res.Projects, p => Assert.NotNull(p.Users));
            Assert.All(res.Projects, p => Assert.NotNull(p.Budget));
            Assert.All(res.Projects, p => Assert.NotEqual(default(int), p.Budget.Value));
            Assert.All(res.Projects, p => Assert.NotEqual(default(int), p.Budget.Progress));
            Assert.All(res.Projects, p => Assert.Equal(Models.BudgetType.MONEY, p.Budget.Type));
            Assert.All(res.Projects, p => Assert.NotNull(p.Billing));
            Assert.All(res.Projects, p => Assert.Equal(Models.BillingType.FLAT_RATE, p.Billing.Type));
            Assert.All(res.Projects, p => Assert.NotEqual(default(int), p.Billing.Rate));
            Assert.All(res.Projects, p => Assert.NotNull(p.Billing.Users));
        }

        [Fact]
        public async Task CreateProjectAsync_ReturnsProject()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.CREATE_PROJECT)));
            var res = await MockApi.Object.CreateProjectAsync("Test Project", Models.ProjectType.BOARD);

            Assert.NotNull(res);
            Assert.NotNull(res.Project.Id);
            Assert.NotNull(res.Project.Name);
            Assert.NotNull(res.Project.WorkspaceId);
            Assert.NotNull(res.Project.Workspace);
            Assert.Equal(Models.ProjectType.BOARD, res.Project.Type);
            Assert.True(res.Project.Favorite);
            Assert.NotNull(res.Project.Users);
            Assert.NotNull(res.Project.Budget);
            Assert.NotEqual(default(int), res.Project.Budget.Value);
            Assert.NotEqual(default(int), res.Project.Budget.Progress);
            Assert.Equal(Models.BudgetType.MONEY, res.Project.Budget.Type);
            Assert.NotNull(res.Project.Billing);
            Assert.Equal(Models.BillingType.FLAT_RATE, res.Project.Billing.Type);
            Assert.NotEqual(default(int), res.Project.Billing.Rate);
            Assert.NotNull(res.Project.Billing.Users);
        }

        [Fact]
        public async Task CreateProjectAsyncWithRequest_ReturnsProject()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.CREATE_PROJECT)));

            var req = new Models.CreateProjectRequest()
            {
                Name = "Test Client",
                Type = Models.ProjectType.BOARD,
                Users = new List<int>() { 1, 2, 3}
            };
            var res = await MockApi.Object.CreateProjectAsync(req);

            Assert.NotNull(res);
            Assert.NotNull(res.Project.Id);
            Assert.NotNull(res.Project.Name);
            Assert.NotNull(res.Project.WorkspaceId);
            Assert.NotNull(res.Project.Workspace);
            Assert.Equal(Models.ProjectType.BOARD, res.Project.Type);
            Assert.True(res.Project.Favorite);
            Assert.NotNull(res.Project.Users);
            Assert.NotNull(res.Project.Budget);
            Assert.NotEqual(default(int), res.Project.Budget.Value);
            Assert.NotEqual(default(int), res.Project.Budget.Progress);
            Assert.Equal(Models.BudgetType.MONEY, res.Project.Budget.Type);
            Assert.NotNull(res.Project.Billing);
            Assert.Equal(Models.BillingType.FLAT_RATE, res.Project.Billing.Type);
            Assert.NotEqual(default(int), res.Project.Billing.Rate);
            Assert.NotNull(res.Project.Billing.Users);
        }

        [Fact]
        public async Task RetrieveProjectAsync_ReturnsProject()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.RETRIEVE_PROJECT)));
            var res = await MockApi.Object.RetrieveProjectAsync("as:1234567890");

            Assert.NotNull(res);
            Assert.NotNull(res.Project.Id);
            Assert.NotNull(res.Project.Name);
            Assert.NotNull(res.Project.WorkspaceId);
            Assert.NotNull(res.Project.Workspace);
            Assert.Equal(Models.ProjectType.BOARD, res.Project.Type);
            Assert.True(res.Project.Favorite);
            Assert.NotNull(res.Project.Users);
            Assert.NotNull(res.Project.Budget);
            Assert.NotEqual(default(int), res.Project.Budget.Value);
            Assert.NotEqual(default(int), res.Project.Budget.Progress);
            Assert.Equal(Models.BudgetType.MONEY, res.Project.Budget.Type);
            Assert.NotNull(res.Project.Billing);
            Assert.Equal(Models.BillingType.FLAT_RATE, res.Project.Billing.Type);
            Assert.NotEqual(default(int), res.Project.Billing.Rate);
            Assert.NotNull(res.Project.Billing.Users);
        }

        [Fact]
        public async Task UpdateProjectAsync_ReturnsProject()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.UPDATE_PROJECT)));
            var res = await MockApi.Object.UpdateProjectAsync("as:1234567890", "Test Project", Models.ProjectType.LIST);

            Assert.NotNull(res);
            Assert.NotNull(res.Project.Id);
            Assert.NotNull(res.Project.Name);
            Assert.NotNull(res.Project.WorkspaceId);
            Assert.NotNull(res.Project.Workspace);
            Assert.Equal(Models.ProjectType.BOARD, res.Project.Type);
            Assert.True(res.Project.Favorite);
            Assert.NotNull(res.Project.Users);
            Assert.NotNull(res.Project.Budget);
            Assert.NotEqual(default(int), res.Project.Budget.Value);
            Assert.NotEqual(default(int), res.Project.Budget.Progress);
            Assert.Equal(Models.BudgetType.MONEY, res.Project.Budget.Type);
            Assert.NotNull(res.Project.Billing);
            Assert.Equal(Models.BillingType.FLAT_RATE, res.Project.Billing.Type);
            Assert.NotEqual(default(int), res.Project.Billing.Rate);
            Assert.NotNull(res.Project.Billing.Users);
        }

        [Fact]
        public async Task UpdateProjectAsyncWithRequest_ReturnsProject()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.UPDATE_PROJECT)));
                
            var req = new Models.UpdateProjectRequest()
            {
                Id = "as:1234567890",
                Name = "Test Client",
                Type = Models.ProjectType.BOARD,
                Users = new List<int>() { 1, 2, 3}
            };
            var res = await MockApi.Object.UpdateProjectAsync(req);

            Assert.NotNull(res);
            Assert.NotNull(res.Project.Id);
            Assert.NotNull(res.Project.Name);
            Assert.NotNull(res.Project.WorkspaceId);
            Assert.NotNull(res.Project.Workspace);
            Assert.Equal(Models.ProjectType.BOARD, res.Project.Type);
            Assert.True(res.Project.Favorite);
            Assert.NotNull(res.Project.Users);
            Assert.NotNull(res.Project.Budget);
            Assert.NotEqual(default(int), res.Project.Budget.Value);
            Assert.NotEqual(default(int), res.Project.Budget.Progress);
            Assert.Equal(Models.BudgetType.MONEY, res.Project.Budget.Type);
            Assert.NotNull(res.Project.Billing);
            Assert.Equal(Models.BillingType.FLAT_RATE, res.Project.Billing.Type);
            Assert.NotEqual(default(int), res.Project.Billing.Rate);
            Assert.NotNull(res.Project.Billing.Users);
        }

        [Fact]
        public async Task DeleteProjectAsync_ReturnsIsSuucessful()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse()));

            var res = await MockApi.Object.DeleteProjectAsync("as:1234567890");

            Assert.True(res);
        }

        [Fact]
        public async Task SetProjectBudgetAsync_ReturnsProject()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.SET_PROJECT_BUDGET)));
            var res = await MockApi.Object.SetProjectBudgetAsync("as:1234567890", Models.BudgetType.MONEY, 1);

            Assert.NotNull(res);
            Assert.NotNull(res.Project.Id);
            Assert.NotNull(res.Project.Name);
            Assert.NotNull(res.Project.WorkspaceId);
            Assert.NotNull(res.Project.Workspace);
            Assert.Equal(Models.ProjectType.BOARD, res.Project.Type);
            Assert.True(res.Project.Favorite);
            Assert.NotNull(res.Project.Users);
            Assert.NotNull(res.Project.Budget);
            Assert.NotEqual(default(int), res.Project.Budget.Value);
            Assert.NotEqual(default(int), res.Project.Budget.Progress);
            Assert.Equal(Models.BudgetType.MONEY, res.Project.Budget.Type);
            Assert.NotNull(res.Project.Billing);
            Assert.Equal(Models.BillingType.FLAT_RATE, res.Project.Billing.Type);
            Assert.NotEqual(default(int), res.Project.Billing.Rate);
            Assert.NotNull(res.Project.Billing.Users);
        }

        [Fact]
        public async Task DeleteProjectBudgetAsync_ReturnsIsSuucessful()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse()));
            var res = await MockApi.Object.DeleteProjectBudgetAsync("as:1234567890");

            Assert.True(res);
        }

        [Fact]
        public async Task SetProjectBillingAsync_ReturnsProject()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.SET_PROJECT_BILLING)));
            var res = await MockApi.Object.SetProjectBillingAsync("as:1234567890", Models.BillingType.FLAT_RATE);

            Assert.NotNull(res);
            Assert.NotNull(res.Project.Id);
            Assert.NotNull(res.Project.Name);
            Assert.NotNull(res.Project.WorkspaceId);
            Assert.NotNull(res.Project.Workspace);
            Assert.Equal(Models.ProjectType.BOARD, res.Project.Type);
            Assert.True(res.Project.Favorite);
            Assert.NotNull(res.Project.Users);
            Assert.NotNull(res.Project.Budget);
            Assert.NotEqual(default(int), res.Project.Budget.Value);
            Assert.NotEqual(default(int), res.Project.Budget.Progress);
            Assert.Equal(Models.BudgetType.MONEY, res.Project.Budget.Type);
            Assert.NotNull(res.Project.Billing);
            Assert.Equal(Models.BillingType.FLAT_RATE, res.Project.Billing.Type);
            Assert.NotEqual(default(int), res.Project.Billing.Rate);
            Assert.NotNull(res.Project.Billing.Users);
        }

        [Fact]
        public async Task SetProjectBillingAsyncWithRequest_ReturnsProject()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.UPDATE_PROJECT)));
                
            var req = new Models.SetProjectBillingRequest()
            {
                Id = "as:1234567890",
                Type = Models.BillingType.FLAT_RATE,
                Rate = 10000,
                Users = new List<Models.UserWithRate>() 
                {
                    new Models.UserWithRate() { Id = 1234, Rate = 10000 },
                    new Models.UserWithRate() { Id = 5678, Rate = 10000 }
                }
            };
            var res = await MockApi.Object.SetProjectBillingAsync(req);

            Assert.NotNull(res);
            Assert.NotNull(res.Project.Id);
            Assert.NotNull(res.Project.Name);
            Assert.NotNull(res.Project.WorkspaceId);
            Assert.NotNull(res.Project.Workspace);
            Assert.Equal(Models.ProjectType.BOARD, res.Project.Type);
            Assert.True(res.Project.Favorite);
            Assert.NotNull(res.Project.Users);
            Assert.NotNull(res.Project.Budget);
            Assert.NotEqual(default(int), res.Project.Budget.Value);
            Assert.NotEqual(default(int), res.Project.Budget.Progress);
            Assert.Equal(Models.BudgetType.MONEY, res.Project.Budget.Type);
            Assert.NotNull(res.Project.Billing);
            Assert.Equal(Models.BillingType.FLAT_RATE, res.Project.Billing.Type);
            Assert.NotEqual(default(int), res.Project.Billing.Rate);
            Assert.NotNull(res.Project.Billing.Users);
        }

        [Fact]
        public async Task DeleteProjectBillingAsync_ReturnsIsSuucessful()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse()));
            var res = await MockApi.Object.DeleteProjectBillingAsync("as:1234567890");

            Assert.True(res);
        }
    }
}