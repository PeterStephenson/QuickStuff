using System.Net;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace QuickStuff.Tests;

public class TestApi : WebApplicationFactory<Program>
{
}

public class ApiTests
{
    [Fact]
    public async Task HelloWorld_ShouldReturnHelloWorld()
    {
        var api = new TestApi();
        var mockDatabaseReader = new Mock<IDatabaseHelloWorldReader>();
        mockDatabaseReader.Setup(r => r.ReadHelloWorldTextFromDatabase())
            .Returns("Hello World!");
        var client = api.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton(mockDatabaseReader.Object);
                });
            })
            .CreateClient();

        var response = await client.GetAsync("/helloWorld");
        response.StatusCode.Should().Be(HttpStatusCode.OK, await response.Content.ReadAsStringAsync());

        var body = await response.Content.ReadAsStringAsync();
        body.Should().Be("Hello World!");
    }
}