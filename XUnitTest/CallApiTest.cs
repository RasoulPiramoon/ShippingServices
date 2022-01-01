using Moq;
using Moq.Protected;
using ShippingService.Dtos;
using ShippingService.Repository;
using ShippingService.Repository.CallApiImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest
{
    public class CallApiTest
    {
        Mock<HttpMessageHandler> handlerMock;
        public CallApiTest()
        {
            handlerMock = new Mock<HttpMessageHandler>();
        }

        [Fact]
        public async Task CallAsJson_Float_ResponseSuccesfully()
        {
            //arrange
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("150")
            };

            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);
            var calApi = new CallAPI(httpClient);

            //act
            var result = await calApi.CallAsJson("Http://localhost:3208", "test");

            //assert
            handlerMock.Protected().Verify(
               "SendAsync",
               Times.Exactly(1),
               ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post),
               ItExpr.IsAny<CancellationToken>());
            Assert.Equal(150, result);
        }

        [Fact]
        public async Task CallAsXml_Float_ResponseSuccesfully()
        {
            //arrange
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("<totalAmount>151</totalAmount>")
            };

            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);
            var calApi = new CallAPI(httpClient);

            //act
            var result = await calApi.CallAsXml("Http://localhost:3208", "test");

            //assert
            handlerMock.Protected().Verify(
               "SendAsync",
               Times.Exactly(1),
               ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post),
               ItExpr.IsAny<CancellationToken>());
            Assert.Equal(151, result);
        }
    }
}
