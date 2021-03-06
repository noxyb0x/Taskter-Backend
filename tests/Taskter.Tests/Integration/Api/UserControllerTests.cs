using FluentAssertions;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using Taskter.Api;
using Taskter.Tests.Helpers.Extensions;
using Taskter.Tests.Helpers.Factories;

namespace Taskter.Tests.Integration.Api
{
    [TestFixture]
    public class UserControllerTests
    {
        private HttpClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().CreateClient();
        }

        [Test]
        public async Task GetCurrentUser_InvokeFuncition_ReturnsCurrentlyLoggedInUser()
        {

            var result = await _client.GetCurrentUser();

            result.Should().NotBeNull();
            result.FirstName.Should().Be("Nermin");

        }

        public async Task GetAllUsers_InvokeFunction_ReturnNonEmptyListWhenReturningAllUsers()
        {
            var result = await _client.GetAllUsers();

            result.Should().NotBeNull();
        }
    }
}
