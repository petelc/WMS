using System;

namespace API.Tests;

public class RequestControllerTest : IClassFixture<TestDatabaseFixture>
{
    public RequestControllerTest(TestDatabaseFixture fixture) => Fixture = fixture;

    public TestDatabaseFixture Fixture { get; }

    [Fact]
    public async Task GetRequest()
    {
        // Arrange
        var client = Fixture.CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/request");

        // Act
        var response = await client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
    }
    
}
