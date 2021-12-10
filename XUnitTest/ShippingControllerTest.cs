using Microsoft.AspNetCore.Mvc;
using Moq;
using ShippingService.Controllers;
using ShippingService.Dtos;
using ShippingService.Repository;
using System;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest
{
    public class ShippingControllerTest
    {
        private readonly Mock<IShippingRepository> _repo;
        public ShippingControllerTest()
        {
            _repo = new Mock<IShippingRepository>();
        }

        [Fact]
        public async Task GetCheapest_Float_Exist()
        {
            //arrange
            _repo.Setup(c => c.GetCheapest(It.IsAny<ShippingRequestDto>()))
                .ReturnsAsync(150);
            var controller = new ShippingController(_repo.Object);

            //act
            var actionResult = await controller.GetCheapest(It.IsAny<ShippingRequestDto>());
            var result = actionResult?.Result as OkObjectResult;
            var totalAmount = (float)result?.Value;

            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.True(totalAmount == 150);
        }

        [Fact]
        public async Task GetCheapest_BadRequest_ServicesThrowException()
        {
            //arrange
            _repo.Setup(c => c.GetCheapest(It.IsAny<ShippingRequestDto>()))
                .ReturnsAsync(-1);
            var controller = new ShippingController(_repo.Object);

            //act
            var actionResult = await controller.GetCheapest(It.IsAny<ShippingRequestDto>());
            var result = actionResult?.Result as BadRequestObjectResult;

            //assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
