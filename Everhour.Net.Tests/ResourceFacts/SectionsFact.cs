using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Everhour.Net.Tests.ResourceFacts
{
    public class SectionsFact : FactBase
    {
        [Fact]
        public async Task ListProjectSectionsAsync_ReturnsSections()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.LIST_PROJECT_SECTIONS)));
            var res = await MockApi.Object.ListProjectSectionsAsync("ev:1234567890");

            Assert.NotNull(res);
            Assert.All(res.Sections, s => Assert.NotEqual(default(int), s.Id));
            Assert.All(res.Sections, s => Assert.NotNull(s.Name));
            Assert.All(res.Sections, s => Assert.NotEqual(default(int), s.Position));
            Assert.All(res.Sections, s => Assert.NotNull(s.Project));
            Assert.All(res.Sections, s => Assert.Equal(Models.SectionStatus.OPEN, s.Status));
        }

        [Fact]
        public async Task CreateSectionAsync_ReturnsSection()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.CREATE_SECTION)));
            var res = await MockApi.Object.CreateSectionAsync("as:1234567890", "Test Section");

            Assert.NotNull(res);
            Assert.NotEqual(default(int), res.Section.Id);
            Assert.NotNull(res.Section.Name);
            Assert.NotEqual(default(int), res.Section.Position);
            Assert.NotNull(res.Section.Project);
            Assert.Equal(Models.SectionStatus.OPEN, res.Section.Status);
        }

       [Fact]
        public async Task CreateSectionAsyncWithReqest_ReturnsSection()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.CREATE_SECTION)));

            var req = new Models.CreateSectionRequest()
            {
                ProjectId = "as:1234567890",
                Name = "Test Section",
                Position = 1,
                Status = Models.SectionStatus.OPEN
            };
            var res = await MockApi.Object.CreateSectionAsync(req);

            Assert.NotNull(res);
            Assert.NotEqual(default(int), res.Section.Id);
            Assert.NotNull(res.Section.Name);
            Assert.NotEqual(default(int), res.Section.Position);
            Assert.NotNull(res.Section.Project);
            Assert.Equal(Models.SectionStatus.OPEN, res.Section.Status);
        }

        [Fact]
        public async Task RetrieveSectionAsync_ReturnsSection()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.RETRIEVE_SECTION)));
            var res = await MockApi.Object.RetrieveSectionAsync(1234);

            Assert.NotNull(res);
            Assert.NotEqual(default(int), res.Section.Id);
            Assert.NotNull(res.Section.Name);
            Assert.NotEqual(default(int), res.Section.Position);
            Assert.NotNull(res.Section.Project);
            Assert.Equal(Models.SectionStatus.OPEN, res.Section.Status);
        }

        [Fact]
        public async Task UpdateSectionAsync_ReturnsSection()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.UPDATE_SECTION)));
            var res = await MockApi.Object.UpdateSectionAsync(1234, "Test Section");

            Assert.NotNull(res);
            Assert.NotEqual(default(int), res.Section.Id);
            Assert.NotNull(res.Section.Name);
            Assert.NotEqual(default(int), res.Section.Position);
            Assert.NotNull(res.Section.Project);
            Assert.Equal(Models.SectionStatus.OPEN, res.Section.Status);
        }

        [Fact]
        public async Task DeleteSectionAsync_ReturnsSection()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse()));
            var res = await MockApi.Object.DeleteSectionAsync(1234);

            Assert.True(res);
        }
    }
}