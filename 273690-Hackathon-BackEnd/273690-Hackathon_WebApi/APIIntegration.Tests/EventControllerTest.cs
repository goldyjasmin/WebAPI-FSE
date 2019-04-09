using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using Xunit;
using System.Threading.Tasks;
using System.Net;
using _273690_Hackathon_WebApi;

namespace APIIntegration.Tests
{
    public class EventControllerTest
    {
        private readonly HttpClient _client;
        public EventControllerTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());

            _client = server.CreateClient();
        }

        [Theory]
        [InlineData("Get",273690)]
        public async Task GeAllEventIdTest(string method ,int? id)
        {
            var req = new HttpRequestMessage(new HttpMethod(method), $"api/events/eventnames/{id}");

            var respone = await _client.SendAsync(req);
            
            Assert.Equal(HttpStatusCode.Unauthorized, respone.StatusCode);
        }

    }
}
