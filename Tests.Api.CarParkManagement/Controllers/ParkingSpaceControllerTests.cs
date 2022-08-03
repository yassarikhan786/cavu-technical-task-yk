using Api.CarParkManagement.Controllers;
using Common.Extensions;
using Moq;
using Services.Db.Interfaces;

namespace Tests.Api.CarParkManagement.Controllers
{
    public class ParkingSpaceControllerTests
    {
        #region Setup

        private ParkingSpaceController Setup(string returnData)
        {
            var mockParkingSpaceService = SetupParkingSpaceServiceMock(returnData);
            return new ParkingSpaceController(mockParkingSpaceService);
        }

        private IParkingSpaceService SetupParkingSpaceServiceMock(string returnData)
        {
            var parkingSpaceService = new Mock<IParkingSpaceService>();
            parkingSpaceService.Setup(x => x.GetAvailableParkingServices(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(returnData);

            return parkingSpaceService.Object;
        }

        #endregion Setup

        [Fact]
        public void Test_Get_Available_Parking_Spaces_Returns_Ok()
        {
            // Arrange
            var parkingSpaceController = Setup(@"[
                {
                    ""isAvailable"": true,
                    ""dateFrom"": ""2022-08-03T00:00:00"",
                    ""dateTo"": ""2022-08-09T00:00:00""
                },
                {
                    ""isAvailable"": true,
                    ""dateFrom"": ""2022-08-13T00:00:00"",
                    ""dateTo"": ""2022-08-19T00:00:00""
                }]");


            // Act
            var actual = parkingSpaceController.GetAvailableParkingSpaces(DateTime.Now, DateTime.Now);
            var statusCode = actual.StatusCode();
            var parkingSpaces = actual.GetValue();


            // Assert
            Assert.Equal(200, statusCode);
            Assert.Equal(2, parkingSpaces.Count);
        }

        [Fact]
        public void Test_Get_Available_Parking_Spaces_Returns_Not_Found()
        {
            // Arrange
            var parkingSpaceController = Setup(string.Empty);

            // Act
            var actual = parkingSpaceController.GetAvailableParkingSpaces(DateTime.Now, DateTime.Now);
            var statusCode = actual.StatusCode();
            var parkingSpaces = actual.GetValue();

            // Assert
            Assert.Equal(404, statusCode);
            Assert.Null(parkingSpaces);
        }
    }
}