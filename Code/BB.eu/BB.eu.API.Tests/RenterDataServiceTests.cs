using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using BB.eu.API.Data;
using BB.eu.API.Mapper;
using BB.eu.API.Services;
using BB.eu.Shared.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace BB.eu.API.Tests
{
    public class RenterDataServiceTests
    {
        private readonly RenterDataService dataService;

        public RenterDataServiceTests()
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var factory = new DataContextFactory(config.Build());

            DataContext context = factory.CreateDbContext();

            context.ChangeTracker
                .Entries()
                .ToList()
                .ForEach(e => e.State = EntityState.Detached);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            // transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew);
            context.Database.CloseConnection();

            dataService = new RenterDataService(factory);
        }

        [Fact]
        public async Task CreateAsyncAndGetAll_WithValidRenter_CreatesAndReturnsSameRenterSuccessfully()
        {
            //Arrange
            Renter renter = CreateRandomRenter();

            //Act
            await dataService.CreateAsync(renter);
            var renters = await dataService.GetAllAsync();

            //Assert
            renters[0].Should().BeEquivalentTo(renter);
        }

        [Fact]
        public async Task UpdateAsync_WithExistingRenter_UpdatesRenter()
        {
            //Arrange
            Renter renter = CreateRandomRenter();
            Renter renter2 = renter;

            //Act
            await dataService.CreateAsync(renter);
            renter.FirstName = "New Name";
            await dataService.UpdateAsync(renter);
            var result = dataService.GetByIdAsync(renter.Id);

            //Assert
            result.Should().NotBeEquivalentTo(renter2);
        }

        [Fact]
        public async Task CreateAsync_WithRenterWithExistingEmail_ReturnsNull()
        {
            //Arrange
            Renter renter = CreateRandomRenter();

            //Act
            await dataService.CreateAsync(renter);
            var result = await dataService.CreateAsync(renter);

            //Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task DeleteByIdAsync_WithValidId_RemoveRenterFromDb()
        {
            //Arrange
            Renter renter = CreateRandomRenter();

            //Act
            await dataService.CreateAsync(renter);
            await dataService.DeleteByIdAsync(renter.Id);

            var result = await dataService.GetByIdAsync(renter.Id);

            //Assert
            result.Should().BeNull();
        }

        private static Renter CreateRandomRenter()
        {
            return new Renter
            {
                FirstName = Guid.NewGuid().ToString(),
                LastName = Guid.NewGuid().ToString(),
                Email = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
            };
        }
    }
}