using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace BangazonTest
{
    public class ExerciseTest : IClassFixture<WebApplicationFactory<Bangazon.Startup>>
    {
        private readonly WebApplicationFactory<Bangazon.Startup> _factory;

        public ExerciseTest(WebApplicationFactory<Bangazon.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Products")]
        [InlineData("/Products/Details/1")]
        [InlineData("/Products/Types")]
        [InlineData("/Products/Create")]
        [InlineData("/Products/Edit/1")]
        [InlineData("/Products/Delete/1")]
        [InlineData("/Products/Search")]
        [InlineData("/ProductTypes")]
        [InlineData("/ProductTypes/Details/1")]
        [InlineData("/ProductTypes/Create")]
        [InlineData("/ProductTypes/Edit/1")]
        [InlineData("/ProductTypes/Delete/1")]
        [InlineData("/PaymentTypes")]
        [InlineData("/PaymentTypes/Details/1")]
        [InlineData("/PaymentTypes/Create")]
        [InlineData("/PaymentTypes/Edit/1")]
        [InlineData("/PaymentTypes/Delete/1")]
        [InlineData("/Orders")]
        [InlineData("/Orders/Details/1")]
        [InlineData("/Orders/Create")]
        [InlineData("/Orders/Edit/1")]
        [InlineData("/Orders/Delete/1")]
        [InlineData("/OrderProducts")]
        [InlineData("/OrderProducts/Details/1")]
        [InlineData("/OrderProducts/Create")]
        [InlineData("/OrderProducts/Edit/1")]
        [InlineData("/OrderProducts/Delete/1")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task Post_DeleteAllMessagesHandler_ReturnsRedirectToRoot()
        {
            // Arrange
            var _client = _factory.CreateClient();

            //Act
            var response = await _client.GetAsync("/");
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Matches("&copy; 2017 - Workforce", content);
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
