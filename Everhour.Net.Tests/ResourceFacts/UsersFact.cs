using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Everhour.Net.Tests.ResourceFacts
{
    public class UsersFact : FactBase
    {
        [Fact]
        public async Task MeAsync_ReturnsUser()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                { 
                    Content = new StringContent(Specification.ME)
                }));
            var res = await MockApi.Object.MeAsync();

            Assert.NotNull(res);
            Assert.NotEqual(default(int), res.Me.Id);
            Assert.Equal(Models.RoleType.ADMIN, res.Me.Role);
            Assert.Equal(Models.UserStatus.ACTIVE, res.Me.Status);
        }

        [Fact]
        public async Task ListTeamUsersAsync_ReturnsUsers()
        {
            MockApi.Setup(x => x.ExecuteAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task.FromResult(GenerateMockResponse(Specification.LIST_USERS)));
            var res = await MockApi.Object.ListTeamUsersAsync();

            Assert.NotNull(res.Users);
            Assert.All(res.Users, user => Assert.NotEqual(default(int), user.Id));
            Assert.All(res.Users, user => Assert.Equal(Models.RoleType.ADMIN, user.Role));
            Assert.All(res.Users, user => Assert.Equal(Models.UserStatus.ACTIVE, user.Status));
        }
    }
}