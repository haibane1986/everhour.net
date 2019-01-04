using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Everhour.Net.Tests.ResourceFacts
{
    public class TasksFact: FactBase
    {
        [Fact]
        public async Task ListProjectTasksAsync_ReturnsTasks()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.LIST_PROJECT_TASKS)));
            var res = await MockApi.Object.ListProjectTasksAsync("ev:1234567890");

            Assert.NotNull(res);
            Assert.All(res.Tasks, t => Assert.NotNull(t.Id));
            Assert.All(res.Tasks, t => Assert.NotNull(t.Name));
            Assert.All(res.Tasks, t => Assert.NotNull(t.Projects));
            Assert.All(res.Tasks, t => Assert.NotEqual(default(int), t.Section));
            Assert.All(res.Tasks, t => Assert.NotNull(t.Labels));
            Assert.All(res.Tasks, t => Assert.NotEqual(default(int), t.Position));
            Assert.All(res.Tasks, t => Assert.NotNull(t.Description));
            Assert.All(res.Tasks, t => Assert.NotEqual(default(DateTime), t.DueAt));
            Assert.All(res.Tasks, t => Assert.Equal(Models.TaskStatus.OPEN, t.Status));
            Assert.All(res.Tasks, t => Assert.NotEqual(default(int), t.Time.Total));
            Assert.All(res.Tasks, t => Assert.NotNull(t.Time.Users));
            Assert.All(res.Tasks, t => Assert.NotEqual(default(int), t.Estimate.Total));
            Assert.All(res.Tasks, t => Assert.Equal(Models.EstimateType.OVERALL, t.Estimate.Type));
            Assert.All(res.Tasks, t => Assert.NotNull(t.Estimate.Users));
            Assert.All(res.Tasks, t => Assert.Equal("Everhour", t.Attributes[0].Client));
            Assert.All(res.Tasks, t => Assert.Equal("hight", t.Attributes[0].Priority));
            Assert.All(res.Tasks, t => Assert.Equal(42, t.Metrics[0].Efforts));
            Assert.All(res.Tasks, t => Assert.Equal(199, t.Metrics[0].Expenses));
        }
        
        [Fact]
        public async Task CreateTaskAsync_ReturnsTask()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.CREATE_TASK)));
            var res = await MockApi.Object.CreateTaskAsync("ev:1234567890", "Task Name", 1234);

            Assert.NotNull(res);
            Assert.NotNull(res.Task.Id);
            Assert.NotNull(res.Task.Name);
            Assert.NotNull(res.Task.Projects);
            Assert.NotEqual(default(int), res.Task.Section);
            Assert.NotNull(res.Task.Labels);
            Assert.NotEqual(default(int), res.Task.Position);
            Assert.NotNull(res.Task.Description);
            Assert.NotEqual(default(DateTime), res.Task.DueAt);
            Assert.Equal(Models.TaskStatus.OPEN, res.Task.Status);
            Assert.NotEqual(default(int), res.Task.Time.Total);
            Assert.NotNull(res.Task.Time.Users);
            Assert.NotEqual(default(int), res.Task.Estimate.Total);
            Assert.Equal(Models.EstimateType.OVERALL, res.Task.Estimate.Type);
            Assert.NotNull(res.Task.Estimate.Users);
            Assert.Equal("Everhour", res.Task.Attributes[0].Client);
            Assert.Equal("hight", res.Task.Attributes[0].Priority);
            Assert.Equal(42, res.Task.Metrics[0].Efforts);
            Assert.Equal(199, res.Task.Metrics[0].Expenses);
        }

        [Fact]
        public async Task CreateTaskAsyncWithRequest_ReturnsTask()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.CREATE_TASK)));

            var req = new Models.CreateTaskRequest() 
            {
                ProjectId = "ev:1234567890",
                Name = "Task Name",
                Section = 1234,
                Labels = new List<string>() { "Label1", "Label2" },
                Position = 1,
                Description = "Description",
                DueAt = DateTime.UtcNow,
                Status = Models.TaskStatus.OPEN
            };
            var res = await MockApi.Object.CreateTaskAsync(req);

            Assert.NotNull(res);
            Assert.NotNull(res.Task.Id);
            Assert.NotNull(res.Task.Name);
            Assert.NotNull(res.Task.Projects);
            Assert.NotEqual(default(int), res.Task.Section);
            Assert.NotNull(res.Task.Labels);
            Assert.NotEqual(default(int), res.Task.Position);
            Assert.NotNull(res.Task.Description);
            Assert.NotEqual(default(DateTime), res.Task.DueAt);
            Assert.Equal(Models.TaskStatus.OPEN, res.Task.Status);
            Assert.NotEqual(default(int), res.Task.Time.Total);
            Assert.NotNull(res.Task.Time.Users);
            Assert.NotEqual(default(int), res.Task.Estimate.Total);
            Assert.Equal(Models.EstimateType.OVERALL, res.Task.Estimate.Type);
            Assert.NotNull(res.Task.Estimate.Users);
            Assert.Equal("Everhour", res.Task.Attributes[0].Client);
            Assert.Equal("hight", res.Task.Attributes[0].Priority);
            Assert.Equal(42, res.Task.Metrics[0].Efforts);
            Assert.Equal(199, res.Task.Metrics[0].Expenses);
        }

        [Fact]
        public async Task RetrieveTaskAsync_ReturnsTask()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.RETRIEVE_TASK)));

            var res = await MockApi.Object.RetrieveTaskAsync("ev:9876543210");

            Assert.NotNull(res);
            Assert.NotNull(res.Task.Id);
            Assert.NotNull(res.Task.Name);
            Assert.NotNull(res.Task.Projects);
            Assert.NotEqual(default(int), res.Task.Section);
            Assert.NotNull(res.Task.Labels);
            Assert.NotEqual(default(int), res.Task.Position);
            Assert.NotNull(res.Task.Description);
            Assert.NotEqual(default(DateTime), res.Task.DueAt);
            Assert.Equal(Models.TaskStatus.OPEN, res.Task.Status);
            Assert.NotEqual(default(int), res.Task.Time.Total);
            Assert.NotNull(res.Task.Time.Users);
            Assert.NotEqual(default(int), res.Task.Estimate.Total);
            Assert.Equal(Models.EstimateType.OVERALL, res.Task.Estimate.Type);
            Assert.NotNull(res.Task.Estimate.Users);
            Assert.Equal("Everhour", res.Task.Attributes[0].Client);
            Assert.Equal("hight", res.Task.Attributes[0].Priority);
            Assert.Equal(42, res.Task.Metrics[0].Efforts);
            Assert.Equal(199, res.Task.Metrics[0].Expenses);
        }

        [Fact]
        public async Task UpdateTaskAsync_ReturnsTask()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.UPDATE_TASK)));

            var res = await MockApi.Object.UpdateTaskAsync("ev:9876543210", "Task Name", 1234);

            Assert.NotNull(res);
            Assert.NotNull(res.Task.Id);
            Assert.NotNull(res.Task.Name);
            Assert.NotNull(res.Task.Projects);
            Assert.NotEqual(default(int), res.Task.Section);
            Assert.NotNull(res.Task.Labels);
            Assert.NotEqual(default(int), res.Task.Position);
            Assert.NotNull(res.Task.Description);
            Assert.NotEqual(default(DateTime), res.Task.DueAt);
            Assert.Equal(Models.TaskStatus.OPEN, res.Task.Status);
            Assert.NotEqual(default(int), res.Task.Time.Total);
            Assert.NotNull(res.Task.Time.Users);
            Assert.NotEqual(default(int), res.Task.Estimate.Total);
            Assert.Equal(Models.EstimateType.OVERALL, res.Task.Estimate.Type);
            Assert.NotNull(res.Task.Estimate.Users);
            Assert.Equal("Everhour", res.Task.Attributes[0].Client);
            Assert.Equal("hight", res.Task.Attributes[0].Priority);
            Assert.Equal(42, res.Task.Metrics[0].Efforts);
            Assert.Equal(199, res.Task.Metrics[0].Expenses);
        }

        [Fact]
        public async Task UpdateTaskAsyncWithRequest_ReturnsTask()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.UPDATE_TASK)));
            
            var req = new Models.UpdateTaskRequest()
            {
                Id = "ev:9876543210",
                Name = "Task Name",
                Section = 1234,
                Labels = new List<string>() { "Label1", "Label2" },
                Position = 1,
                Description = "Description",
                DueAt = DateTime.UtcNow,
                Status = Models.TaskStatus.OPEN
            };
            var res = await MockApi.Object.UpdateTaskAsync(req);

            Assert.NotNull(res);
            Assert.NotNull(res.Task.Id);
            Assert.NotNull(res.Task.Name);
            Assert.NotNull(res.Task.Projects);
            Assert.NotEqual(default(int), res.Task.Section);
            Assert.NotNull(res.Task.Labels);
            Assert.NotEqual(default(int), res.Task.Position);
            Assert.NotNull(res.Task.Description);
            Assert.NotEqual(default(DateTime), res.Task.DueAt);
            Assert.Equal(Models.TaskStatus.OPEN, res.Task.Status);
            Assert.NotEqual(default(int), res.Task.Time.Total);
            Assert.NotNull(res.Task.Time.Users);
            Assert.NotEqual(default(int), res.Task.Estimate.Total);
            Assert.Equal(Models.EstimateType.OVERALL, res.Task.Estimate.Type);
            Assert.NotNull(res.Task.Estimate.Users);
            Assert.Equal("Everhour", res.Task.Attributes[0].Client);
            Assert.Equal("hight", res.Task.Attributes[0].Priority);
            Assert.Equal(42, res.Task.Metrics[0].Efforts);
            Assert.Equal(199, res.Task.Metrics[0].Expenses);
        }

        [Fact]
        public async Task DeleteTaskAsync_ReturnsTask()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse()));
            var res = await MockApi.Object.DeleteTaskAsync("ev:9876543210");

            Assert.True(res);
        }

        [Fact]
        public async Task SetTaskEstimateAsyncByOverAll_ReturnsTask()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.SET_TASK_ESTIMATE)));
            var res = await MockApi.Object.SetTaskEstimateAsyncByOverAll("ev:9876543210",  7200);

            Assert.NotNull(res);
            Assert.NotNull(res.Estimate.Total);
            Assert.NotNull(res.Estimate.Type);
            Assert.Null(res.Estimate.Users);
        }

        [Fact]
        public async Task SetTaskEstimateAsyncWithRequest_ReturnsTask()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.SET_TASK_ESTIMATE)));

            var res = await MockApi.Object.SetTaskEstimateAsyncByUsers("ev:9876543210", new List<Models.UserWithTaskEstimate>() 
            {
                new Models.UserWithTaskEstimate() { Id = 1234, TaskEstimate = 3600 }
            });

            Assert.NotNull(res);
            Assert.NotNull(res.Estimate.Total);
            Assert.NotNull(res.Estimate.Type);
            Assert.Null(res.Estimate.Users);
        }

        [Fact]
        public async Task DeleteTaskEstimateAsync_ReturnsTask()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse()));
            var res = await MockApi.Object.DeleteTaskEstimateAsync("ev:9876543210");

            Assert.True(res);
        }
    }
}