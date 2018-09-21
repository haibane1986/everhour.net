using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Models = Everhour.Net.Models;

namespace Everhour.Net.Tests.ResourceFacts
{
    public class TimeRecordingFact : FactBase
    {
        [Fact]
        public async Task AddTimeToTaskAsync_ReturnsTimeRecord()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.ADD_TIME_TO_TASK)));
            var res = await MockApi.Object.AddTimeToTaskAsync("ev:1234567890", 3600, DateTime.UtcNow);

            Assert.NotNull(res);
            Assert.Equal(2660155, res.TimeRecord.Id);
            Assert.Equal(3600, res.TimeRecord.Time);
            Assert.Equal(1304, res.TimeRecord.User);
            Assert.Equal(new DateTime(2018, 1, 20), res.TimeRecord.Date);
            Assert.Equal("ev:9876543210", res.TimeRecord.Task.Id);
            Assert.Equal("Task Name", res.TimeRecord.Task.Name);
            Assert.Equal(new List<string>() { "ev:1234567890" }, res.TimeRecord.Task.Projects);
            Assert.Equal(1234, res.TimeRecord.Task.Section);
            Assert.Equal(new List<string>() { "high", "bug" }, res.TimeRecord.Task.Labels);
            Assert.Equal(1, res.TimeRecord.Task.Position);
            Assert.Equal("description", res.TimeRecord.Task.Description);
            Assert.Equal(new DateTime(2018, 3, 5, 16, 0, 0), res.TimeRecord.Task.DueAt);
            Assert.Equal(Models.TaskStatus.OPEN, res.TimeRecord.Task.Status);
            Assert.Equal(7200, res.TimeRecord.Task.Time.Total);
            Assert.Equal(1304, res.TimeRecord.Task.Time.Users[0].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Time.Users[0].Time);
            Assert.Equal(1543, res.TimeRecord.Task.Time.Users[1].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Time.Users[1].Time);
            Assert.Equal(7200, res.TimeRecord.Task.Estimate.Total);
            Assert.Equal(Models.EstimateType.OVERALL, res.TimeRecord.Task.Estimate.Type);
            Assert.Equal(1304, res.TimeRecord.Task.Estimate.Users[0].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Estimate.Users[0].Time);
            Assert.Equal(1543, res.TimeRecord.Task.Estimate.Users[1].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Estimate.Users[1].Time);
            Assert.All(res.TimeRecord.Task.Attributes, a => Assert.Equal("Everhour", a.Client));
            Assert.All(res.TimeRecord.Task.Attributes, a => Assert.Equal("hight",a.Priority));
            Assert.All(res.TimeRecord.Task.Metrics, m => Assert.Equal(42, m.Efforts));
            Assert.All(res.TimeRecord.Task.Metrics, m => Assert.Equal(199, m.Expenses));
            Assert.True(res.TimeRecord.IsLocked);
            Assert.True(res.TimeRecord.IsInvoiced);
            Assert.Equal("some notes", res.TimeRecord.Comment);
        }

        [Fact]
        public async Task AddTimeToTaskAsyncWithRequest_ReturnsTimeRecord()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.ADD_TIME_TO_TASK)));

            var req = new Models.AddTimeToTaskRequest() 
            {
                TaskId = "ev:1234567890",
                Time = 3600,
                Date = DateTime.UtcNow,
                User = 1234
            };
            var res = await MockApi.Object.AddTimeToTaskAsync(req);

            Assert.NotNull(res);
            Assert.Equal(2660155, res.TimeRecord.Id);
            Assert.Equal(3600, res.TimeRecord.Time);
            Assert.Equal(1304, res.TimeRecord.User);
            Assert.Equal(new DateTime(2018, 1, 20), res.TimeRecord.Date);
            Assert.Equal("ev:9876543210", res.TimeRecord.Task.Id);
            Assert.Equal("Task Name", res.TimeRecord.Task.Name);
            Assert.Equal(new List<string>() { "ev:1234567890" }, res.TimeRecord.Task.Projects);
            Assert.Equal(1234, res.TimeRecord.Task.Section);
            Assert.Equal(new List<string>() { "high", "bug" }, res.TimeRecord.Task.Labels);
            Assert.Equal(1, res.TimeRecord.Task.Position);
            Assert.Equal("description", res.TimeRecord.Task.Description);
            Assert.Equal(new DateTime(2018, 3, 5, 16, 0, 0), res.TimeRecord.Task.DueAt);
            Assert.Equal(Models.TaskStatus.OPEN, res.TimeRecord.Task.Status);
            Assert.Equal(7200, res.TimeRecord.Task.Time.Total);
            Assert.Equal(1304, res.TimeRecord.Task.Time.Users[0].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Time.Users[0].Time);
            Assert.Equal(1543, res.TimeRecord.Task.Time.Users[1].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Time.Users[1].Time);
            Assert.Equal(7200, res.TimeRecord.Task.Estimate.Total);
            Assert.Equal(Models.EstimateType.OVERALL, res.TimeRecord.Task.Estimate.Type);
            Assert.Equal(1304, res.TimeRecord.Task.Estimate.Users[0].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Estimate.Users[0].Time);
            Assert.Equal(1543, res.TimeRecord.Task.Estimate.Users[1].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Estimate.Users[1].Time);
            Assert.All(res.TimeRecord.Task.Attributes, a => Assert.Equal("Everhour", a.Client));
            Assert.All(res.TimeRecord.Task.Attributes, a => Assert.Equal("hight",a.Priority));
            Assert.All(res.TimeRecord.Task.Metrics, m => Assert.Equal(42, m.Efforts));
            Assert.All(res.TimeRecord.Task.Metrics, m => Assert.Equal(199, m.Expenses));
            Assert.True(res.TimeRecord.IsLocked);
            Assert.True(res.TimeRecord.IsInvoiced);
            Assert.Equal("some notes", res.TimeRecord.Comment);
        }

        [Fact]
        public async Task UpdateTimeInTaskAsync_ReturnsTimeRecord()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.UPDATE_TIME_IN_TASK)));
            var res = await MockApi.Object.UpdateTimeInTaskAsync("ev:1234567890", 3600, DateTime.UtcNow);

            Assert.NotNull(res);
            Assert.Equal(2660155, res.TimeRecord.Id);
            Assert.Equal(3600, res.TimeRecord.Time);
            Assert.Equal(1304, res.TimeRecord.User);
            Assert.Equal(new DateTime(2018, 1, 20), res.TimeRecord.Date);
            Assert.Equal("ev:9876543210", res.TimeRecord.Task.Id);
            Assert.Equal("Task Name", res.TimeRecord.Task.Name);
            Assert.Equal(new List<string>() { "ev:1234567890" }, res.TimeRecord.Task.Projects);
            Assert.Equal(1234, res.TimeRecord.Task.Section);
            Assert.Equal(new List<string>() { "high", "bug" }, res.TimeRecord.Task.Labels);
            Assert.Equal(1, res.TimeRecord.Task.Position);
            Assert.Equal("description", res.TimeRecord.Task.Description);
            Assert.Equal(new DateTime(2018, 3, 5, 16, 0, 0), res.TimeRecord.Task.DueAt);
            Assert.Equal(Models.TaskStatus.OPEN, res.TimeRecord.Task.Status);
            Assert.Equal(7200, res.TimeRecord.Task.Time.Total);
            Assert.Equal(1304, res.TimeRecord.Task.Time.Users[0].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Time.Users[0].Time);
            Assert.Equal(1543, res.TimeRecord.Task.Time.Users[1].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Time.Users[1].Time);
            Assert.Equal(7200, res.TimeRecord.Task.Estimate.Total);
            Assert.Equal(Models.EstimateType.OVERALL, res.TimeRecord.Task.Estimate.Type);
            Assert.Equal(1304, res.TimeRecord.Task.Estimate.Users[0].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Estimate.Users[0].Time);
            Assert.Equal(1543, res.TimeRecord.Task.Estimate.Users[1].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Estimate.Users[1].Time);
            Assert.All(res.TimeRecord.Task.Attributes, a => Assert.Equal("Everhour", a.Client));
            Assert.All(res.TimeRecord.Task.Attributes, a => Assert.Equal("hight",a.Priority));
            Assert.All(res.TimeRecord.Task.Metrics, m => Assert.Equal(42, m.Efforts));
            Assert.All(res.TimeRecord.Task.Metrics, m => Assert.Equal(199, m.Expenses));
            Assert.True(res.TimeRecord.IsLocked);
            Assert.True(res.TimeRecord.IsInvoiced);
            Assert.Equal("some notes", res.TimeRecord.Comment);
        }

        [Fact]
        public async Task UpdateTimeInTaskAsyncWithRequest_ReturnsTimeRecord()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.UPDATE_TIME_IN_TASK)));

            var req = new Models.UpdateTimeInTaskRequest() 
            {
                TaskId = "ev:1234567890",
                Time = 3600,
                Date = DateTime.UtcNow,
                User = 1234
            };
            var res = await MockApi.Object.UpdateTimeInTaskAsync(req);

            Assert.NotNull(res);
            Assert.Equal(2660155, res.TimeRecord.Id);
            Assert.Equal(3600, res.TimeRecord.Time);
            Assert.Equal(1304, res.TimeRecord.User);
            Assert.Equal(new DateTime(2018, 1, 20), res.TimeRecord.Date);
            Assert.Equal("ev:9876543210", res.TimeRecord.Task.Id);
            Assert.Equal("Task Name", res.TimeRecord.Task.Name);
            Assert.Equal(new List<string>() { "ev:1234567890" }, res.TimeRecord.Task.Projects);
            Assert.Equal(1234, res.TimeRecord.Task.Section);
            Assert.Equal(new List<string>() { "high", "bug" }, res.TimeRecord.Task.Labels);
            Assert.Equal(1, res.TimeRecord.Task.Position);
            Assert.Equal("description", res.TimeRecord.Task.Description);
            Assert.Equal(new DateTime(2018, 3, 5, 16, 0, 0), res.TimeRecord.Task.DueAt);
            Assert.Equal(Models.TaskStatus.OPEN, res.TimeRecord.Task.Status);
            Assert.Equal(7200, res.TimeRecord.Task.Time.Total);
            Assert.Equal(1304, res.TimeRecord.Task.Time.Users[0].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Time.Users[0].Time);
            Assert.Equal(1543, res.TimeRecord.Task.Time.Users[1].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Time.Users[1].Time);
            Assert.Equal(7200, res.TimeRecord.Task.Estimate.Total);
            Assert.Equal(Models.EstimateType.OVERALL, res.TimeRecord.Task.Estimate.Type);
            Assert.Equal(1304, res.TimeRecord.Task.Estimate.Users[0].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Estimate.Users[0].Time);
            Assert.Equal(1543, res.TimeRecord.Task.Estimate.Users[1].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Estimate.Users[1].Time);
            Assert.All(res.TimeRecord.Task.Attributes, a => Assert.Equal("Everhour", a.Client));
            Assert.All(res.TimeRecord.Task.Attributes, a => Assert.Equal("hight",a.Priority));
            Assert.All(res.TimeRecord.Task.Metrics, m => Assert.Equal(42, m.Efforts));
            Assert.All(res.TimeRecord.Task.Metrics, m => Assert.Equal(199, m.Expenses));
            Assert.True(res.TimeRecord.IsLocked);
            Assert.True(res.TimeRecord.IsInvoiced);
            Assert.Equal("some notes", res.TimeRecord.Comment);
        }

        [Fact]
        public async Task DeleteTimeInTaskAsync_ReturnsTimeRecord()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.DELETE_TIME_IN_TASK)));
            var res = await MockApi.Object.DeleteTimeInTaskAsync("ev:1234567890", DateTime.UtcNow);

            Assert.NotNull(res);
            Assert.Equal(2660155, res.TimeRecord.Id);
            Assert.Equal(3600, res.TimeRecord.Time);
            Assert.Equal(1304, res.TimeRecord.User);
            Assert.Equal(new DateTime(2018, 1, 20), res.TimeRecord.Date);
            Assert.Equal("ev:9876543210", res.TimeRecord.Task.Id);
            Assert.Equal("Task Name", res.TimeRecord.Task.Name);
            Assert.Equal(new List<string>() { "ev:1234567890" }, res.TimeRecord.Task.Projects);
            Assert.Equal(1234, res.TimeRecord.Task.Section);
            Assert.Equal(new List<string>() { "high", "bug" }, res.TimeRecord.Task.Labels);
            Assert.Equal(1, res.TimeRecord.Task.Position);
            Assert.Equal("description", res.TimeRecord.Task.Description);
            Assert.Equal(new DateTime(2018, 3, 5, 16, 0, 0), res.TimeRecord.Task.DueAt);
            Assert.Equal(Models.TaskStatus.OPEN, res.TimeRecord.Task.Status);
            Assert.Equal(7200, res.TimeRecord.Task.Time.Total);
            Assert.Equal(1304, res.TimeRecord.Task.Time.Users[0].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Time.Users[0].Time);
            Assert.Equal(1543, res.TimeRecord.Task.Time.Users[1].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Time.Users[1].Time);
            Assert.Equal(7200, res.TimeRecord.Task.Estimate.Total);
            Assert.Equal(Models.EstimateType.OVERALL, res.TimeRecord.Task.Estimate.Type);
            Assert.Equal(1304, res.TimeRecord.Task.Estimate.Users[0].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Estimate.Users[0].Time);
            Assert.Equal(1543, res.TimeRecord.Task.Estimate.Users[1].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Estimate.Users[1].Time);
            Assert.All(res.TimeRecord.Task.Attributes, a => Assert.Equal("Everhour", a.Client));
            Assert.All(res.TimeRecord.Task.Attributes, a => Assert.Equal("hight",a.Priority));
            Assert.All(res.TimeRecord.Task.Metrics, m => Assert.Equal(42, m.Efforts));
            Assert.All(res.TimeRecord.Task.Metrics, m => Assert.Equal(199, m.Expenses));
            Assert.True(res.TimeRecord.IsLocked);
            Assert.True(res.TimeRecord.IsInvoiced);
            Assert.Equal("some notes", res.TimeRecord.Comment);
        }

        [Fact]
        public async Task DeleteTimeInTaskAsyncWithRequest_ReturnsTimeRecord()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.DELETE_TIME_IN_TASK)));

            var req = new Models.DeleteTimeInTaskRequest() 
            {
                TaskId = "ev:1234567890",
                Date = DateTime.UtcNow,
                User = 1234
            };
            var res = await MockApi.Object.DeleteTimeInTaskAsync(req);

            Assert.NotNull(res);
            Assert.Equal(2660155, res.TimeRecord.Id);
            Assert.Equal(3600, res.TimeRecord.Time);
            Assert.Equal(1304, res.TimeRecord.User);
            Assert.Equal(new DateTime(2018, 1, 20), res.TimeRecord.Date);
            Assert.Equal("ev:9876543210", res.TimeRecord.Task.Id);
            Assert.Equal("Task Name", res.TimeRecord.Task.Name);
            Assert.Equal(new List<string>() { "ev:1234567890" }, res.TimeRecord.Task.Projects);
            Assert.Equal(1234, res.TimeRecord.Task.Section);
            Assert.Equal(new List<string>() { "high", "bug" }, res.TimeRecord.Task.Labels);
            Assert.Equal(1, res.TimeRecord.Task.Position);
            Assert.Equal("description", res.TimeRecord.Task.Description);
            Assert.Equal(new DateTime(2018, 3, 5, 16, 0, 0), res.TimeRecord.Task.DueAt);
            Assert.Equal(Models.TaskStatus.OPEN, res.TimeRecord.Task.Status);
            Assert.Equal(7200, res.TimeRecord.Task.Time.Total);
            Assert.Equal(1304, res.TimeRecord.Task.Time.Users[0].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Time.Users[0].Time);
            Assert.Equal(1543, res.TimeRecord.Task.Time.Users[1].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Time.Users[1].Time);
            Assert.Equal(7200, res.TimeRecord.Task.Estimate.Total);
            Assert.Equal(Models.EstimateType.OVERALL, res.TimeRecord.Task.Estimate.Type);
            Assert.Equal(1304, res.TimeRecord.Task.Estimate.Users[0].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Estimate.Users[0].Time);
            Assert.Equal(1543, res.TimeRecord.Task.Estimate.Users[1].Id);
            Assert.Equal(3600, res.TimeRecord.Task.Estimate.Users[1].Time);
            Assert.All(res.TimeRecord.Task.Attributes, a => Assert.Equal("Everhour", a.Client));
            Assert.All(res.TimeRecord.Task.Attributes, a => Assert.Equal("hight",a.Priority));
            Assert.All(res.TimeRecord.Task.Metrics, m => Assert.Equal(42, m.Efforts));
            Assert.All(res.TimeRecord.Task.Metrics, m => Assert.Equal(199, m.Expenses));
            Assert.True(res.TimeRecord.IsLocked);
            Assert.True(res.TimeRecord.IsInvoiced);
            Assert.Equal("some notes", res.TimeRecord.Comment);
        }

        [Fact]
        public async Task ListUserTimeRecordsAsync_ReturnsTimeRecord()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.LIST_USER_TIME_RECORDS)));
            var res = await MockApi.Object.ListUserTimeRecordsAsync(1234, 100);

            Assert.NotNull(res);
            Assert.All(res.TimeRecords, t => Assert.Equal(2660155, t.Id));
            Assert.All(res.TimeRecords, t => Assert.Equal(3600, t.Time));
            Assert.All(res.TimeRecords, t => Assert.Equal(1304, t.User));
            Assert.All(res.TimeRecords, t => Assert.Equal(new DateTime(2018, 1, 20), t.Date));
            Assert.All(res.TimeRecords, t => Assert.Equal("ev:9876543210", t.Task.Id));
            Assert.All(res.TimeRecords, t => Assert.Equal("Task Name", t.Task.Name));
            Assert.All(res.TimeRecords, t => Assert.Equal(new List<string>() { "ev:1234567890" }, t.Task.Projects));
            Assert.All(res.TimeRecords, t => Assert.Equal(1234, t.Task.Section));
            Assert.All(res.TimeRecords, t => Assert.Equal(new List<string>() { "high", "bug" },  t.Task.Labels));
            Assert.All(res.TimeRecords, t => Assert.Equal(1, t.Task.Position));
            Assert.All(res.TimeRecords, t => Assert.Equal("description", t.Task.Description));
            Assert.All(res.TimeRecords, t => Assert.Equal(new DateTime(2018, 3, 5, 16, 0, 0), t.Task.DueAt));
            Assert.All(res.TimeRecords, t => Assert.Equal(Models.TaskStatus.OPEN, t.Task.Status));
            Assert.All(res.TimeRecords, t => Assert.Equal(7200, t.Task.Time.Total));
            Assert.All(res.TimeRecords, t => Assert.Equal(1304, t.Task.Time.Users[0].Id));
            Assert.All(res.TimeRecords, t => Assert.Equal(3600, t.Task.Time.Users[0].Time));
            Assert.All(res.TimeRecords, t => Assert.Equal(1543, t.Task.Time.Users[1].Id));
            Assert.All(res.TimeRecords, t => Assert.Equal(3600, t.Task.Time.Users[1].Time));
            Assert.All(res.TimeRecords, t => Assert.Equal(7200, t.Task.Estimate.Total));
            Assert.All(res.TimeRecords, t => Assert.Equal(Models.EstimateType.OVERALL, t.Task.Estimate.Type));
            Assert.All(res.TimeRecords, t => Assert.Equal(1304, t.Task.Estimate.Users[0].Id));
            Assert.All(res.TimeRecords, t => Assert.Equal(3600, t.Task.Estimate.Users[0].Time));
            Assert.All(res.TimeRecords, t => Assert.Equal(1543, t.Task.Estimate.Users[1].Id));
            Assert.All(res.TimeRecords, t => Assert.Equal(3600, t.Task.Estimate.Users[1].Time));
            Assert.All(res.TimeRecords, t => Assert.All(t.Task.Attributes, a => Assert.Equal("Everhour", a.Client)));
            Assert.All(res.TimeRecords, t => Assert.All(t.Task.Attributes, a => Assert.Equal("hight",a.Priority)));
            Assert.All(res.TimeRecords, t => Assert.All(t.Task.Metrics, m => Assert.Equal(42, m.Efforts)));
            Assert.All(res.TimeRecords, t => Assert.All(t.Task.Metrics, m => Assert.Equal(199, m.Expenses)));
            Assert.All(res.TimeRecords, t => Assert.True(t.IsLocked));
            Assert.All(res.TimeRecords, t => Assert.True(t.IsInvoiced));
            Assert.All(res.TimeRecords, t => Assert.Equal("some notes", t.Comment));
        }

        [Fact]
        public async Task ListUserTimeRecordsAsyncWithRequest_ReturnsTimeRecord()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.LIST_USER_TIME_RECORDS)));

            var req = new Models.ListUserTimeRecordsRequest()
            {
                UserId = 1234,
                Limit = 100,
                Offset = 1
            };
            var res = await MockApi.Object.ListUserTimeRecordsAsync(req);

            Assert.NotNull(res);
            Assert.All(res.TimeRecords, t => Assert.Equal(2660155, t.Id));
            Assert.All(res.TimeRecords, t => Assert.Equal(3600, t.Time));
            Assert.All(res.TimeRecords, t => Assert.Equal(1304, t.User));
            Assert.All(res.TimeRecords, t => Assert.Equal(new DateTime(2018, 1, 20), t.Date));
            Assert.All(res.TimeRecords, t => Assert.Equal("ev:9876543210", t.Task.Id));
            Assert.All(res.TimeRecords, t => Assert.Equal("Task Name", t.Task.Name));
            Assert.All(res.TimeRecords, t => Assert.Equal(new List<string>() { "ev:1234567890" }, t.Task.Projects));
            Assert.All(res.TimeRecords, t => Assert.Equal(1234, t.Task.Section));
            Assert.All(res.TimeRecords, t => Assert.Equal(new List<string>() { "high", "bug" },  t.Task.Labels));
            Assert.All(res.TimeRecords, t => Assert.Equal(1, t.Task.Position));
            Assert.All(res.TimeRecords, t => Assert.Equal("description", t.Task.Description));
            Assert.All(res.TimeRecords, t => Assert.Equal(new DateTime(2018, 3, 5, 16, 0, 0), t.Task.DueAt));
            Assert.All(res.TimeRecords, t => Assert.Equal(Models.TaskStatus.OPEN, t.Task.Status));
            Assert.All(res.TimeRecords, t => Assert.Equal(7200, t.Task.Time.Total));
            Assert.All(res.TimeRecords, t => Assert.Equal(1304, t.Task.Time.Users[0].Id));
            Assert.All(res.TimeRecords, t => Assert.Equal(3600, t.Task.Time.Users[0].Time));
            Assert.All(res.TimeRecords, t => Assert.Equal(1543, t.Task.Time.Users[1].Id));
            Assert.All(res.TimeRecords, t => Assert.Equal(3600, t.Task.Time.Users[1].Time));
            Assert.All(res.TimeRecords, t => Assert.Equal(7200, t.Task.Estimate.Total));
            Assert.All(res.TimeRecords, t => Assert.Equal(Models.EstimateType.OVERALL, t.Task.Estimate.Type));
            Assert.All(res.TimeRecords, t => Assert.Equal(1304, t.Task.Estimate.Users[0].Id));
            Assert.All(res.TimeRecords, t => Assert.Equal(3600, t.Task.Estimate.Users[0].Time));
            Assert.All(res.TimeRecords, t => Assert.Equal(1543, t.Task.Estimate.Users[1].Id));
            Assert.All(res.TimeRecords, t => Assert.Equal(3600, t.Task.Estimate.Users[1].Time));
            Assert.All(res.TimeRecords, t => Assert.All(t.Task.Attributes, a => Assert.Equal("Everhour", a.Client)));
            Assert.All(res.TimeRecords, t => Assert.All(t.Task.Attributes, a => Assert.Equal("hight",a.Priority)));
            Assert.All(res.TimeRecords, t => Assert.All(t.Task.Metrics, m => Assert.Equal(42, m.Efforts)));
            Assert.All(res.TimeRecords, t => Assert.All(t.Task.Metrics, m => Assert.Equal(199, m.Expenses)));
            Assert.All(res.TimeRecords, t => Assert.True(t.IsLocked));
            Assert.All(res.TimeRecords, t => Assert.True(t.IsInvoiced));
            Assert.All(res.TimeRecords, t => Assert.Equal("some notes", t.Comment));
        }

        [Fact]
        public async Task ListTeamTimeRecordsAsync_ReturnsTimeRecord()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.LIST_TEAM_TIME_RECORDS)));
            var res = await MockApi.Object.ListTeamTimeRecordsAsync();

            Assert.NotNull(res);
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(2660155, t.Id));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(3600, t.Time));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(1304, t.User));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(new DateTime(2018, 1, 20), t.Date));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal("ev:9876543210", t.Task.Id));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal("Task Name", t.Task.Name));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(new List<string>() { "ev:1234567890" }, t.Task.Projects));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(1234, t.Task.Section));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(new List<string>() { "high", "bug" },  t.Task.Labels));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(1, t.Task.Position));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal("description", t.Task.Description));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(new DateTime(2018, 3, 5, 16, 0, 0), t.Task.DueAt));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(Models.TaskStatus.OPEN, t.Task.Status));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(7200, t.Task.Time.Total));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(1304, t.Task.Time.Users[0].Id));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(3600, t.Task.Time.Users[0].Time));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(1543, t.Task.Time.Users[1].Id));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(3600, t.Task.Time.Users[1].Time));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(7200, t.Task.Estimate.Total));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(Models.EstimateType.OVERALL, t.Task.Estimate.Type));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(1304, t.Task.Estimate.Users[0].Id));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(3600, t.Task.Estimate.Users[0].Time));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(1543, t.Task.Estimate.Users[1].Id));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(3600, t.Task.Estimate.Users[1].Time));
            Assert.All(res.TeamTimeRecords, t => Assert.All(t.Task.Attributes, a => Assert.Equal("Everhour", a.Client)));
            Assert.All(res.TeamTimeRecords, t => Assert.All(t.Task.Attributes, a => Assert.Equal("hight",a.Priority)));
            Assert.All(res.TeamTimeRecords, t => Assert.All(t.Task.Metrics, m => Assert.Equal(42, m.Efforts)));
            Assert.All(res.TeamTimeRecords, t => Assert.All(t.Task.Metrics, m => Assert.Equal(199, m.Expenses)));
            Assert.All(res.TeamTimeRecords, t => Assert.True(t.IsLocked));
            Assert.All(res.TeamTimeRecords, t => Assert.True(t.IsInvoiced));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal("some notes", t.Comment));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(4622379, t.History[0].Id));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(1304, t.History[0].CreatedBy));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(3600, t.History[0].Time));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(0, t.History[0].PreviousTime));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(Models.HistoryStatus.TIMER, t.History[0].Status));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(new DateTime(2018, 1, 16, 12, 42, 59), t.History[0].CreatedAt));
        }

        [Fact]
        public async Task ListTeamTimeRecordsAsyncWithRequest_ReturnsTimeRecord()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.LIST_TEAM_TIME_RECORDS)));
            
            var req = new Models.ListTeamTimeRecordsRequest()
            {
                From = DateTime.UtcNow,
                To = DateTime.UtcNow,
                Date = DateTime.UtcNow
            };
            var res = await MockApi.Object.ListTeamTimeRecordsAsync(req);

            Assert.NotNull(res);
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(2660155, t.Id));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(3600, t.Time));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(1304, t.User));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(new DateTime(2018, 1, 20), t.Date));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal("ev:9876543210", t.Task.Id));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal("Task Name", t.Task.Name));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(new List<string>() { "ev:1234567890" }, t.Task.Projects));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(1234, t.Task.Section));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(new List<string>() { "high", "bug" },  t.Task.Labels));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(1, t.Task.Position));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal("description", t.Task.Description));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(new DateTime(2018, 3, 5, 16, 0, 0), t.Task.DueAt));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(Models.TaskStatus.OPEN, t.Task.Status));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(7200, t.Task.Time.Total));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(1304, t.Task.Time.Users[0].Id));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(3600, t.Task.Time.Users[0].Time));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(1543, t.Task.Time.Users[1].Id));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(3600, t.Task.Time.Users[1].Time));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(7200, t.Task.Estimate.Total));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(Models.EstimateType.OVERALL, t.Task.Estimate.Type));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(1304, t.Task.Estimate.Users[0].Id));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(3600, t.Task.Estimate.Users[0].Time));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(1543, t.Task.Estimate.Users[1].Id));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(3600, t.Task.Estimate.Users[1].Time));
            Assert.All(res.TeamTimeRecords, t => Assert.All(t.Task.Attributes, a => Assert.Equal("Everhour", a.Client)));
            Assert.All(res.TeamTimeRecords, t => Assert.All(t.Task.Attributes, a => Assert.Equal("hight",a.Priority)));
            Assert.All(res.TeamTimeRecords, t => Assert.All(t.Task.Metrics, m => Assert.Equal(42, m.Efforts)));
            Assert.All(res.TeamTimeRecords, t => Assert.All(t.Task.Metrics, m => Assert.Equal(199, m.Expenses)));
            Assert.All(res.TeamTimeRecords, t => Assert.True(t.IsLocked));
            Assert.All(res.TeamTimeRecords, t => Assert.True(t.IsInvoiced));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal("some notes", t.Comment));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(4622379, t.History[0].Id));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(1304, t.History[0].CreatedBy));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(3600, t.History[0].Time));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(0, t.History[0].PreviousTime));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(Models.HistoryStatus.TIMER, t.History[0].Status));
            Assert.All(res.TeamTimeRecords, t => Assert.Equal(new DateTime(2018, 1, 16, 12, 42, 59), t.History[0].CreatedAt));
        }

        [Fact]
        public async Task ListTaskTimeRecordsAsync_ReturnsTimeRecord()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.LIST_USER_TIME_RECORDS)));
            var res = await MockApi.Object.ListTaskTimeRecordsAsync("ev:9876543210");

            Assert.NotNull(res);
            Assert.All(res.TimeRecords, t => Assert.Equal(2660155, t.Id));
            Assert.All(res.TimeRecords, t => Assert.Equal(3600, t.Time));
            Assert.All(res.TimeRecords, t => Assert.Equal(1304, t.User));
            Assert.All(res.TimeRecords, t => Assert.Equal(new DateTime(2018, 1, 20), t.Date));
            Assert.All(res.TimeRecords, t => Assert.Equal("ev:9876543210", t.Task.Id));
            Assert.All(res.TimeRecords, t => Assert.Equal("Task Name", t.Task.Name));
            Assert.All(res.TimeRecords, t => Assert.Equal(new List<string>() { "ev:1234567890" }, t.Task.Projects));
            Assert.All(res.TimeRecords, t => Assert.Equal(1234, t.Task.Section));
            Assert.All(res.TimeRecords, t => Assert.Equal(new List<string>() { "high", "bug" },  t.Task.Labels));
            Assert.All(res.TimeRecords, t => Assert.Equal(1, t.Task.Position));
            Assert.All(res.TimeRecords, t => Assert.Equal("description", t.Task.Description));
            Assert.All(res.TimeRecords, t => Assert.Equal(new DateTime(2018, 3, 5, 16, 0, 0), t.Task.DueAt));
            Assert.All(res.TimeRecords, t => Assert.Equal(Models.TaskStatus.OPEN, t.Task.Status));
            Assert.All(res.TimeRecords, t => Assert.Equal(7200, t.Task.Time.Total));
            Assert.All(res.TimeRecords, t => Assert.Equal(1304, t.Task.Time.Users[0].Id));
            Assert.All(res.TimeRecords, t => Assert.Equal(3600, t.Task.Time.Users[0].Time));
            Assert.All(res.TimeRecords, t => Assert.Equal(1543, t.Task.Time.Users[1].Id));
            Assert.All(res.TimeRecords, t => Assert.Equal(3600, t.Task.Time.Users[1].Time));
            Assert.All(res.TimeRecords, t => Assert.Equal(7200, t.Task.Estimate.Total));
            Assert.All(res.TimeRecords, t => Assert.Equal(Models.EstimateType.OVERALL, t.Task.Estimate.Type));
            Assert.All(res.TimeRecords, t => Assert.Equal(1304, t.Task.Estimate.Users[0].Id));
            Assert.All(res.TimeRecords, t => Assert.Equal(3600, t.Task.Estimate.Users[0].Time));
            Assert.All(res.TimeRecords, t => Assert.Equal(1543, t.Task.Estimate.Users[1].Id));
            Assert.All(res.TimeRecords, t => Assert.Equal(3600, t.Task.Estimate.Users[1].Time));
            Assert.All(res.TimeRecords, t => Assert.All(t.Task.Attributes, a => Assert.Equal("Everhour", a.Client)));
            Assert.All(res.TimeRecords, t => Assert.All(t.Task.Attributes, a => Assert.Equal("hight",a.Priority)));
            Assert.All(res.TimeRecords, t => Assert.All(t.Task.Metrics, m => Assert.Equal(42, m.Efforts)));
            Assert.All(res.TimeRecords, t => Assert.All(t.Task.Metrics, m => Assert.Equal(199, m.Expenses)));
            Assert.All(res.TimeRecords, t => Assert.True(t.IsLocked));
            Assert.All(res.TimeRecords, t => Assert.True(t.IsInvoiced));
            Assert.All(res.TimeRecords, t => Assert.Equal("some notes", t.Comment));
        }
    }
}