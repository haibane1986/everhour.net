using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Everhour.Net.Tests.ResourceFacts
{
    public class Timers : FactBase
    {
        [Fact]
        public async Task StartTimerAsync_ReturnsTimer()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                { 
                    Content = new StringContent(Specification.START_TIMER)
                }));
            var res = await MockApi.Object.StartTimerAsync("ev:9876543210");

            Assert.NotNull(res);
            Assert.Equal(Models.TimerStatus.ACTIVE, res.Timer.Status);
            Assert.Equal(16, res.Timer.Duration);
            Assert.Equal(7200, res.Timer.Today);
            Assert.Equal(new DateTime(2018, 01, 16, 12, 42, 59), res.Timer.StartedAt);
            Assert.Equal(new DateTime(2018, 01, 16), res.Timer.UserDate);
            Assert.Equal("comment", res.Timer.Comment);
            Assert.Equal(1234, res.Timer.Task.Section);
            Assert.Equal(new List<string>() { "high", "bug" }, res.Timer.Task.Labels);
            Assert.Equal(1, res.Timer.Task.Position);
            Assert.Equal("description", res.Timer.Task.Description);
            Assert.Equal(new DateTime(2018, 3, 5, 16, 0, 0), res.Timer.Task.DueAt);
            Assert.Equal(Models.TaskStatus.OPEN, res.Timer.Task.Status);
            Assert.Equal(7200, res.Timer.Task.Time.Total);
            Assert.Equal(1304, res.Timer.Task.Time.Users[0].Id);
            Assert.Equal(3600, res.Timer.Task.Time.Users[0].Time);
            Assert.Equal(1543, res.Timer.Task.Time.Users[1].Id);
            Assert.Equal(3600, res.Timer.Task.Time.Users[1].Time);
            Assert.Equal(7200, res.Timer.Task.Estimate.Total);
            Assert.Equal(Models.EstimateType.OVERALL, res.Timer.Task.Estimate.Type);
            Assert.Equal(1304, res.Timer.Task.Estimate.Users[0].Id);
            Assert.Equal(3600, res.Timer.Task.Estimate.Users[0].Time);
            Assert.Equal(1543, res.Timer.Task.Estimate.Users[1].Id);
            Assert.Equal(3600, res.Timer.Task.Estimate.Users[1].Time);
            Assert.All(res.Timer.Task.Attributes, a => Assert.Equal("Everhour", a.Client));
            Assert.All(res.Timer.Task.Attributes, a => Assert.Equal("hight",a.Priority));
            Assert.All(res.Timer.Task.Metrics, m => Assert.Equal(42, m.Efforts));
            Assert.All(res.Timer.Task.Metrics, m => Assert.Equal(199, m.Expenses));
            Assert.Equal(1304, res.Timer.User.Id);
            Assert.Equal("User Name", res.Timer.User.Name);
            Assert.Equal("CEO", res.Timer.User.Headline);
            Assert.Equal(Models.RoleType.ADMIN, res.Timer.User.Role);
            Assert.Equal(Models.UserStatus.ACTIVE, res.Timer.User.Status);
        }

        [Fact]
        public async Task StartTimerAsyncWithRequest_ReturnsTimer()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                { 
                    Content = new StringContent(Specification.START_TIMER)
                }));
            
            var req = new Models.StartTimerRequest() 
            {
                TaskId = "ev:1234567890",
                UserDate = DateTime.UtcNow,
                Comment = "comment"
            };
            var res = await MockApi.Object.StartTimerAsync(req);

            Assert.NotNull(res);
            Assert.Equal(Models.TimerStatus.ACTIVE, res.Timer.Status);
            Assert.Equal(16, res.Timer.Duration);
            Assert.Equal(7200, res.Timer.Today);
            Assert.Equal(new DateTime(2018, 01, 16, 12, 42, 59), res.Timer.StartedAt);
            Assert.Equal(new DateTime(2018, 01, 16), res.Timer.UserDate);
            Assert.Equal("comment", res.Timer.Comment);
            Assert.Equal(1234, res.Timer.Task.Section);
            Assert.Equal(new List<string>() { "high", "bug" }, res.Timer.Task.Labels);
            Assert.Equal(1, res.Timer.Task.Position);
            Assert.Equal("description", res.Timer.Task.Description);
            Assert.Equal(new DateTime(2018, 3, 5, 16, 0, 0), res.Timer.Task.DueAt);
            Assert.Equal(Models.TaskStatus.OPEN, res.Timer.Task.Status);
            Assert.Equal(7200, res.Timer.Task.Time.Total);
            Assert.Equal(1304, res.Timer.Task.Time.Users[0].Id);
            Assert.Equal(3600, res.Timer.Task.Time.Users[0].Time);
            Assert.Equal(1543, res.Timer.Task.Time.Users[1].Id);
            Assert.Equal(3600, res.Timer.Task.Time.Users[1].Time);
            Assert.Equal(7200, res.Timer.Task.Estimate.Total);
            Assert.Equal(Models.EstimateType.OVERALL, res.Timer.Task.Estimate.Type);
            Assert.Equal(1304, res.Timer.Task.Estimate.Users[0].Id);
            Assert.Equal(3600, res.Timer.Task.Estimate.Users[0].Time);
            Assert.Equal(1543, res.Timer.Task.Estimate.Users[1].Id);
            Assert.Equal(3600, res.Timer.Task.Estimate.Users[1].Time);
            Assert.All(res.Timer.Task.Attributes, a => Assert.Equal("Everhour", a.Client));
            Assert.All(res.Timer.Task.Attributes, a => Assert.Equal("hight",a.Priority));
            Assert.All(res.Timer.Task.Metrics, m => Assert.Equal(42, m.Efforts));
            Assert.All(res.Timer.Task.Metrics, m => Assert.Equal(199, m.Expenses));
            Assert.Equal(1304, res.Timer.User.Id);
            Assert.Equal("User Name", res.Timer.User.Name);
            Assert.Equal("CEO", res.Timer.User.Headline);
            Assert.Equal(Models.RoleType.ADMIN, res.Timer.User.Role);
            Assert.Equal(Models.UserStatus.ACTIVE, res.Timer.User.Status);
        }

        [Fact]
        public async Task RetrieveRunningTimerAsync_ReturnsTimer()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                { 
                    Content = new StringContent(Specification.RETRIEVE_RUNNING_TIMER)
                }));

            var res = await MockApi.Object.RetrieveRunningTimerAsync();

            Assert.NotNull(res);
            Assert.Equal(Models.TimerStatus.ACTIVE, res.Timer.Status);
            Assert.Equal(16, res.Timer.Duration);
            Assert.Equal(7200, res.Timer.Today);
            Assert.Equal(new DateTime(2018, 01, 16, 12, 42, 59), res.Timer.StartedAt);
            Assert.Equal(new DateTime(2018, 01, 16), res.Timer.UserDate);
            Assert.Equal("comment", res.Timer.Comment);
            Assert.Equal(1234, res.Timer.Task.Section);
            Assert.Equal(new List<string>() { "high", "bug" }, res.Timer.Task.Labels);
            Assert.Equal(1, res.Timer.Task.Position);
            Assert.Equal("description", res.Timer.Task.Description);
            Assert.Equal(new DateTime(2018, 3, 5, 16, 0, 0), res.Timer.Task.DueAt);
            Assert.Equal(Models.TaskStatus.OPEN, res.Timer.Task.Status);
            Assert.Equal(7200, res.Timer.Task.Time.Total);
            Assert.Equal(1304, res.Timer.Task.Time.Users[0].Id);
            Assert.Equal(3600, res.Timer.Task.Time.Users[0].Time);
            Assert.Equal(1543, res.Timer.Task.Time.Users[1].Id);
            Assert.Equal(3600, res.Timer.Task.Time.Users[1].Time);
            Assert.Equal(7200, res.Timer.Task.Estimate.Total);
            Assert.Equal(Models.EstimateType.OVERALL, res.Timer.Task.Estimate.Type);
            Assert.Equal(1304, res.Timer.Task.Estimate.Users[0].Id);
            Assert.Equal(3600, res.Timer.Task.Estimate.Users[0].Time);
            Assert.Equal(1543, res.Timer.Task.Estimate.Users[1].Id);
            Assert.Equal(3600, res.Timer.Task.Estimate.Users[1].Time);
            Assert.All(res.Timer.Task.Attributes, a => Assert.Equal("Everhour", a.Client));
            Assert.All(res.Timer.Task.Attributes, a => Assert.Equal("hight",a.Priority));
            Assert.All(res.Timer.Task.Metrics, m => Assert.Equal(42, m.Efforts));
            Assert.All(res.Timer.Task.Metrics, m => Assert.Equal(199, m.Expenses));
            Assert.Equal(1304, res.Timer.User.Id);
            Assert.Equal("User Name", res.Timer.User.Name);
            Assert.Equal("CEO", res.Timer.User.Headline);
            Assert.Equal(Models.RoleType.ADMIN, res.Timer.User.Role);
            Assert.Equal(Models.UserStatus.ACTIVE, res.Timer.User.Status);
        }

        [Fact]
        public async Task StopTimerAsync_ReturnsTimer()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                { 
                    Content = new StringContent(Specification.STOP_TIMER)
                }));

            var res = await MockApi.Object.StopTimerAsync();

            Assert.NotNull(res);
            Assert.Equal(Models.TimerStatus.ACTIVE, res.Timer.Status);
            Assert.Equal(16, res.Timer.Duration);
            Assert.Equal(7200, res.Timer.Today);
            Assert.Equal(new DateTime(2018, 01, 16, 12, 42, 59), res.Timer.StartedAt);
            Assert.Equal(new DateTime(2018, 01, 16), res.Timer.UserDate);
            Assert.Equal("comment", res.Timer.Comment);
            Assert.Equal(1234, res.Timer.Task.Section);
            Assert.Equal(new List<string>() { "high", "bug" }, res.Timer.Task.Labels);
            Assert.Equal(1, res.Timer.Task.Position);
            Assert.Equal("description", res.Timer.Task.Description);
            Assert.Equal(new DateTime(2018, 3, 5, 16, 0, 0), res.Timer.Task.DueAt);
            Assert.Equal(Models.TaskStatus.OPEN, res.Timer.Task.Status);
            Assert.Equal(7200, res.Timer.Task.Time.Total);
            Assert.Equal(1304, res.Timer.Task.Time.Users[0].Id);
            Assert.Equal(3600, res.Timer.Task.Time.Users[0].Time);
            Assert.Equal(1543, res.Timer.Task.Time.Users[1].Id);
            Assert.Equal(3600, res.Timer.Task.Time.Users[1].Time);
            Assert.Equal(7200, res.Timer.Task.Estimate.Total);
            Assert.Equal(Models.EstimateType.OVERALL, res.Timer.Task.Estimate.Type);
            Assert.Equal(1304, res.Timer.Task.Estimate.Users[0].Id);
            Assert.Equal(3600, res.Timer.Task.Estimate.Users[0].Time);
            Assert.Equal(1543, res.Timer.Task.Estimate.Users[1].Id);
            Assert.Equal(3600, res.Timer.Task.Estimate.Users[1].Time);
            Assert.All(res.Timer.Task.Attributes, a => Assert.Equal("Everhour", a.Client));
            Assert.All(res.Timer.Task.Attributes, a => Assert.Equal("hight",a.Priority));
            Assert.All(res.Timer.Task.Metrics, m => Assert.Equal(42, m.Efforts));
            Assert.All(res.Timer.Task.Metrics, m => Assert.Equal(199, m.Expenses));
            Assert.Equal(1304, res.Timer.User.Id);
            Assert.Equal("User Name", res.Timer.User.Name);
            Assert.Equal("CEO", res.Timer.User.Headline);
            Assert.Equal(Models.RoleType.ADMIN, res.Timer.User.Role);
            Assert.Equal(Models.UserStatus.ACTIVE, res.Timer.User.Status);
        }

        [Fact]
        public async Task ListTeamUsersTimersAsync_ReturnsTimers()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                { 
                    Content = new StringContent(Specification.LIST_TEAM_USERS_TIMERS)
                }));

            var res = await MockApi.Object.ListTeamUsersTimersAsync();

            Assert.NotNull(res);
            Assert.All(res.Timers, e => Assert.Equal(Models.TimerStatus.ACTIVE, e.Status));
            Assert.All(res.Timers, e => Assert.Equal(16, e.Duration));
            Assert.All(res.Timers, e => Assert.Equal(7200, e.Today));
            Assert.All(res.Timers, e => Assert.Equal(new DateTime(2018, 01, 16, 12, 42, 59), e.StartedAt));
            Assert.All(res.Timers, e => Assert.Equal(new DateTime(2018, 01, 16), e.UserDate));
            Assert.All(res.Timers, e => Assert.Equal("comment", e.Comment));
            Assert.All(res.Timers, e => Assert.Equal(1234, e.Task.Section));
            Assert.All(res.Timers, e => Assert.Equal(new List<string>() { "high", "bug" }, e.Task.Labels));
            Assert.All(res.Timers, e => Assert.Equal(1, e.Task.Position));
            Assert.All(res.Timers, e => Assert.Equal("description", e.Task.Description));
            Assert.All(res.Timers, e => Assert.Equal(new DateTime(2018, 3, 5, 16, 0, 0), e.Task.DueAt));
            Assert.All(res.Timers, e => Assert.Equal(Models.TaskStatus.OPEN, e.Task.Status));
            Assert.All(res.Timers, e => Assert.Equal(7200, e.Task.Time.Total));
            Assert.All(res.Timers, e => Assert.Equal(1304, e.Task.Time.Users[0].Id));
            Assert.All(res.Timers, e => Assert.Equal(3600, e.Task.Time.Users[0].Time));
            Assert.All(res.Timers, e => Assert.Equal(1543, e.Task.Time.Users[1].Id));
            Assert.All(res.Timers, e => Assert.Equal(3600, e.Task.Time.Users[1].Time));
            Assert.All(res.Timers, e => Assert.Equal(7200, e.Task.Estimate.Total));
            Assert.All(res.Timers, e => Assert.Equal(Models.EstimateType.OVERALL, e.Task.Estimate.Type));
            Assert.All(res.Timers, e => Assert.Equal(1304, e.Task.Estimate.Users[0].Id));
            Assert.All(res.Timers, e => Assert.Equal(3600, e.Task.Estimate.Users[0].Time));
            Assert.All(res.Timers, e => Assert.Equal(1543, e.Task.Estimate.Users[1].Id));
            Assert.All(res.Timers, e => Assert.Equal(3600, e.Task.Estimate.Users[1].Time));
            Assert.All(res.Timers, e => Assert.All(e.Task.Attributes, a => Assert.Equal("Everhour", a.Client)));
            Assert.All(res.Timers, e => Assert.All(e.Task.Attributes, a => Assert.Equal("hight",a.Priority)));
            Assert.All(res.Timers, e => Assert.All(e.Task.Metrics, m => Assert.Equal(42, m.Efforts)));
            Assert.All(res.Timers, e => Assert.All(e.Task.Metrics, m => Assert.Equal(199, m.Expenses)));
            Assert.All(res.Timers, e => Assert.Equal(1304, e.User.Id));
            Assert.All(res.Timers, e => Assert.Equal("User Name", e.User.Name));
            Assert.All(res.Timers, e => Assert.Equal("CEO", e.User.Headline));
            Assert.All(res.Timers, e => Assert.Equal(Models.RoleType.ADMIN, e.User.Role));
            Assert.All(res.Timers, e => Assert.Equal(Models.UserStatus.ACTIVE, e.User.Status));
        }
    }
}