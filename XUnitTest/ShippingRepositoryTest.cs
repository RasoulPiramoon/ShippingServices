using Moq;
using ShippingService.Dtos;
using ShippingService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest
{
    public class ShippingRepositoryTest
    {
        private readonly Mock<ICallApi> calApi;
        public ShippingRepositoryTest()
        {
            calApi = new Mock<ICallApi>();
        }

        [Fact]
        public async Task GetCheapest_Float_Exist()
        {
            //arrange
            var dto = new ShippingRequestDto
            {
                ShippingDestinationAddress = "London",
                ShippingSourceAddress = "Paris",
                ParcelDimensions = new List<ParcelDimension>
                    {
                        new ParcelDimension
                        {
                            Height =10,
                            Length =20,
                            Weight = 100
                        }
                    }
            };
            Random rnd = new Random();
            int[] fakeResult = new int[3] { rnd.Next(1, 1000), rnd.Next(1, 1000), rnd.Next(1, 1000) };
            calApi.SetupSequence(c => c.CallAsJson(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(fakeResult[0])
                .ReturnsAsync(fakeResult[1]);
            calApi.Setup(c => c.CallAsXml(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(fakeResult[2]);
            var repo = new ShippingRepository(calApi.Object);

            //act
            var result = await repo.GetCheapest(dto);

            //assert
            Assert.True(result > -1);
            Assert.Equal(fakeResult.Select(c => c).Min(),result);

        }

        [Fact]
        public async Task GetCheapest_LessThanZero_NoApiIsActiveOrAllApisThrowExceptin()
        {
            //arrange
            var dto = new ShippingRequestDto
            {
                ShippingDestinationAddress = "London",
                ShippingSourceAddress = "Paris",
                ParcelDimensions = new List<ParcelDimension>
                    {
                        new ParcelDimension
                        {
                            Height =10,
                            Length =20,
                            Weight = 100
                        }
                    }
            };
            Random rnd = new Random();
            calApi.Setup(c => c.CallAsJson(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(-1);
            calApi.Setup(c => c.CallAsXml(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(-1);
            var repo = new ShippingRepository(calApi.Object);

            //act
            var result = await repo.GetCheapest(dto);

            //assert
            Assert.True(result == -1);

        }
    }
}
