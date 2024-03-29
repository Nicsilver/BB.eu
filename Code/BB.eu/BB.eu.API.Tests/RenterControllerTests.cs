﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BB.eu.API.Controllers;
using BB.eu.API.Mapper;
using BB.eu.API.Requests;
using BB.eu.API.Responses;
using BB.eu.API.Services;
using BB.eu.Shared.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BB.eu.API.Tests
{
    public class RenterControllerTests
    {
        private readonly Mock<IRenterDataService> dataServiceStub = new();
        private readonly Random rand = new();
        private readonly IMapper mapper;

        public RenterControllerTests()
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

        [Fact]
        public async Task LoginAsync_WithInvalidLoginRequest_ReturnsNotFound()
        {
            // Arrange
            dataServiceStub.Setup(service => service.GetByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((Renter)null);

            RenterController controller = new(dataServiceStub.Object, mapper);

            LoginRequest loginRequest = new()
            {
                Email = "",
                Password = ""
            };
            // Act
            var result = await controller.LoginAsync(loginRequest);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task LoginAsync_WithValidLoginRequest_ReturnsValidRenterLoginResponse()
        {
            // Arrange
            Renter expectedRenter = CreateRandomRenter();

            dataServiceStub.Setup(service => service.GetByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedRenter);

            RenterController controller = new(dataServiceStub.Object, mapper);

            LoginRequest loginRequest = new()
            {
                Email = expectedRenter.Email,
                Password = expectedRenter.Password
            };

            // Act
            var result = await controller.LoginAsync(loginRequest);

            // Assert
            result.Value.Email.Should().Be(expectedRenter.Email);
        }

        [Fact]
        public async Task CreateRenterAsync_WithAlreadyRegisteredEmail_ReturnsBadRequest()
        {
            // Arrange
            dataServiceStub.Setup(service => service.CreateAsync(It.IsAny<Renter>()))
                .ReturnsAsync((Renter)null);

            RenterController controller = new(dataServiceStub.Object, mapper);

            RegisterAccountRequest registerAccountRequest = new();
            //Act
            var result = await controller.CreateRenterAsync(registerAccountRequest);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task CreateRenterAsync_WithValidRequest_ReturnsRenterCreateResponse()
        {
            // Arrange
            var renter = CreateRandomRenter();

            dataServiceStub.Setup(service => service.CreateAsync(It.IsAny<Renter>()))
                .ReturnsAsync(renter);

            RenterController controller = new(dataServiceStub.Object, mapper);

            RegisterAccountRequest registerAccountRequest = new()
            {
                Password = renter.Password,
                Email = renter.Email,
                FirstName = renter.FirstName,
                LastName = renter.LastName
            };

            //Act
            var result = await controller.CreateRenterAsync(registerAccountRequest);

            //Assert
            result.Value.Should().BeEquivalentTo(renter,
                config =>
                    config.ExcludingMissingMembers());
        }

        private Renter CreateRandomRenter()
        {
            return new Renter
            {
                Id = rand.Next(100),
                FirstName = "John",
                LastName = "Smith",
                Email = "smith@email.com",
                Rooms = new List<Room>(),
                Password = "password",
            };
        }
    }
}