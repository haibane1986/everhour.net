using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Models = Everhour.Net.Models;

namespace Everhour.Net.Tests.ResourceFacts
{
    public class Time : FactBase
    {
        [Fact]
        public async Task ExportAllTeamTimeAsync_ReturnsTeamTime()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.EXPORT_TIME)));
            var res = await MockApi.Object.ExportAllTeamTimeAsync(DateTime.UtcNow, DateTime.UtcNow.AddDays(1));

            Assert.NotNull(res);
            Assert.All(res.TeamTimes, e => Assert.NotEqual(default(int), e.Time));
            Assert.All(res.TeamTimes, e => Assert.NotNull(e.Date));
            Assert.All(res.TeamTimes, e => Assert.NotEqual(default(int), e.User.Id));
            Assert.All(res.TeamTimes, e => Assert.NotNull(e.User.Name));
            Assert.All(res.TeamTimes, e => Assert.NotNull(e.Project.Id));
            Assert.All(res.TeamTimes, e => Assert.NotNull(e.Project.Name));
            Assert.All(res.TeamTimes, e => Assert.NotNull(e.Project.Workspace));
            Assert.All(res.TeamTimes, e => Assert.NotNull(e.Task.Id));
            Assert.All(res.TeamTimes, e => Assert.NotNull(e.Task.Name));
            Assert.All(res.TeamTimes, e => Assert.Equal(Models.TaskType.TASK, e.Task.Type));
        }

        [Fact]
        public async Task ExportTeamTimeAsyncWithParams_ReturnsTeamTime()
        {
             MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.EXPORT_TIME)));

            var req = new Models.ExportAllTeamTimeRequest(
                DateTime.UtcNow, 
                DateTime.UtcNow.AddDays(1))
            {
                Fields = Models.ExportAllTeamTimeField.PROJECT 
                | Models.ExportAllTeamTimeField.TASK
                | Models.ExportAllTeamTimeField.DATE
                | Models.ExportAllTeamTimeField.USER
            };
            var res = await MockApi.Object.ExportAllTeamTimeAsync(req);

            Assert.NotNull(res);
            Assert.All(res.TeamTimes, e => Assert.NotEqual(default(int), e.Time));
            Assert.All(res.TeamTimes, e => Assert.NotNull(e.Date));
            Assert.All(res.TeamTimes, e => Assert.NotEqual(default(int), e.Time));
            Assert.All(res.TeamTimes, e => Assert.NotEqual(default(int), e.User.Id));
            Assert.All(res.TeamTimes, e => Assert.NotNull(e.User.Name));
            Assert.All(res.TeamTimes, e => Assert.NotNull(e.Project.Id));
            Assert.All(res.TeamTimes, e => Assert.NotNull(e.Project.Name));
            Assert.All(res.TeamTimes, e => Assert.NotNull(e.Project.Workspace));
            Assert.All(res.TeamTimes, e => Assert.NotNull(e.Task.Id));
            Assert.All(res.TeamTimes, e => Assert.NotNull(e.Task.Name));
            Assert.All(res.TeamTimes, e => Assert.Equal(Models.TaskType.TASK, e.Task.Type));
        }
    }
}