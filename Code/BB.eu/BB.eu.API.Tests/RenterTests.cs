using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BB.eu.API.Controllers;
using BB.eu.API.Mapper;
using BB.eu.API.Services;
using BB.eu.Shared.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BB.eu.API.Tests
{
    public class RenterTests
    {
        private readonly Mock<IRenterDataService> dataServiceStub = new();
        private readonly Random rand = new();
        private readonly IMapper mapper;

        public RenterTests()
        {
            AutoMapperProfiles profiles = new();
            MapperConfiguration configuration = new(cfg => cfg.AddProfile(profiles));
            mapper = configuration.CreateMapper();
        }

        [Fact]
        public async Task GetAsync_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            dataServiceStub.Setup(service => service.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Renter)null);

            RenterController controller = new(dataServiceStub.Object, mapper);

            // Act
            var result = await controller.GetByIdAsync(rand.Next(1000));

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetAsync_WithValidId_ReturnsExpectedEntity()
        {
            // Arrange
            Renter expectedRenter = CreateRandomRenter();

            dataServiceStub.Setup(service => service.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(expectedRenter);

            RenterController controller = new(dataServiceStub.Object, mapper);

            // Act
            var result = await controller.GetByIdAsync(rand.Next(rand.Next(1)));

            // Assert
            result.Value.Should().BeEquivalentTo(expectedRenter);
        }

        private Renter CreateRandomRenter()
        {
            return new Renter
            {
                Id = rand.Next(100),
                FirstName = "",
                LastName = "",
                Age = rand.Next(200),
                Email = "asd",
                Rooms = new List<Room>(),
                Password = "dasd"
            };
        }
    }
}