using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Models = Everhour.Net.Models;

namespace Everhour.Net.Tests.ResourceFacts
{
    public class EstimateFact : FactBase
    {
        [Fact]
        public async Task ExportAllTeamEstimatesAsync_ReturnsTeamEstimates()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.EXPORT_ESITIMATES)));

            var res = await MockApi.Object.ExportAllTeamEstimatesAsync();

            Assert.NotNull(res);
            Assert.All(res.TeamEstimates, e => Assert.NotEqual(default(int), e.Time.Total));
            Assert.All(res.TeamEstimates, e => Assert.NotEqual(default(int), e.Estimate.Total));
            Assert.All(res.TeamEstimates, e => Assert.Equal(Models.EstimateType.OVERALL,  e.Estimate.Type));
            Assert.All(res.TeamEstimates, e => Assert.NotNull(e.Project.Id));
            Assert.All(res.TeamEstimates, e => Assert.NotNull(e.Project.Name));
            Assert.All(res.TeamEstimates, e => Assert.NotNull(e.Project.Workspace));
            Assert.All(res.TeamEstimates, e => Assert.NotNull(e.Task.Id));
            Assert.All(res.TeamEstimates, e => Assert.NotNull(e.Task.Name));
            Assert.All(res.TeamEstimates, e => Assert.Equal(Models.TaskType.TASK, e.Task.Type));
        }

        [Fact]
        public async Task ExportAllTeamEstimatesAsyncWithParams_ReturnsTeamEstimates()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                { 
                    Content = new StringContent(Specification.EXPORT_ESITIMATES)
                }));
            
            var req = new Models.ExportAllTeamEstimatesRequest()
            {
                DueFrom = DateTime.UtcNow, 
                DueTo = DateTime.UtcNow.AddDays(1),
                Status = Models.TaskStatus.OPEN
            };
            var res = await MockApi.Object.ExportAllTeamEstimatesAsync(req);

            Assert.NotNull(res);
            Assert.All(res.TeamEstimates, e => Assert.NotEqual(default(int), e.Time.Total));
            Assert.All(res.TeamEstimates, e => Assert.NotEqual(default(int), e.Estimate.Total));
            Assert.All(res.TeamEstimates, e => Assert.Equal(Models.EstimateType.OVERALL,  e.Estimate.Type));
            Assert.All(res.TeamEstimates, e => Assert.NotNull(e.Project.Id));
            Assert.All(res.TeamEstimates, e => Assert.NotNull(e.Project.Name));
            Assert.All(res.TeamEstimates, e => Assert.NotNull(e.Project.Workspace));
            Assert.All(res.TeamEstimates, e => Assert.NotNull(e.Task.Id));
            Assert.All(res.TeamEstimates, e => Assert.NotNull(e.Task.Name));
            Assert.All(res.TeamEstimates, e => Assert.Equal(Models.TaskType.TASK, e.Task.Type));
        }
    }
}