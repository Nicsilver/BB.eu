using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TDDPrototype.Api.Controllers;
using TDDPrototype.Api.Models;
using TDDPrototype.Api.Services;
using Xunit;

namespace TDDPrototype.test
{
    public class BookingTests
    {
        private readonly Mock<IRoomDataService> dataServiceStub = new();
        private readonly Random rand = new();

        [Fact]
        public async Task GetRoomAsync_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            dataServiceStub.Setup(service => service.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Room)null);

            RoomController controller = new(dataServiceStub.Object);

            // Act
            var result = await controller.GetByIdAsync(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetRoomAsync_WithExistingRoom_ReturnsExpectedItem()
        {
            // Arrange
            Room expectedRoom = CreateRandomRoom();

            dataServiceStub.Setup(service => service.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(expectedRoom);

            RoomController controller = new(dataServiceStub.Object);

            // Act
            var result = await controller.GetByIdAsync(Guid.NewGuid());

            // Assert
            // Assert.IsType<Room>(result.Value);
            result.Value.Should().BeEquivalentTo(expectedRoom);
        }

        private Room CreateRandomRoom()
        {
            return new Room
            {
                Id = Guid.NewGuid(),
                Price = rand.Next(500)
            };
        }
    }
}