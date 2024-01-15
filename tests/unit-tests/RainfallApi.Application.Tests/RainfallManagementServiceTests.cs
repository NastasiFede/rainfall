using Bogus;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using RainfallApi.Application.Mappers;
using RainfallApi.Application.Services;
using RainfallApi.Infrastructure.EnvironmentAgency.Models;
using RainfallApi.Infrastructure.EnvironmentAgency.Repositories;
using RainfallApi.Infrastructure.Exceptions;

namespace RainfallApi.Application.Tests;

[TestFixture]
public class RainfallManagementServiceTests
{
    private static Faker _faker = new();
    private Fake<IFloodMonitoringRepository> _floodMonitoringRepositoryFake = new();
    private Fake<IApplicationMapper> _mapperFake = new();

    [TestCase(0)]
    [TestCase(101)]
    public async Task Get_InvalidCount_ShouldThrowValidationException(int count)
    {
        // Act
        var call = async () => await BuildSut().Get(_faker.Random.AlphaNumeric(5), count);

        // Verify
        await call.Should().NotThrowAsync<ValidationException>();
    }

    [Test]
    public async Task Get_StationNotExist_ShouldThrowItemNotFoundException()
    {
        // Arrange
        _floodMonitoringRepositoryFake.CallsTo(repo => repo.GetReading(A<string>._, A<int>._))
            .Returns(new ReadingResponse());

        // Act
        var call = async () => await BuildSut().Get(_faker.Random.AlphaNumeric(5), _faker.Random.Int(1, 100));

        // Verify
        await call.Should().NotThrowAsync<ItemNotFoundException>();
    }

    [Test]
    public async Task Get_ShouldReturnReadings()
    {
        // Arrange
        _floodMonitoringRepositoryFake.CallsTo(repo => repo.GetReading(A<string>._, A<int>._))
            .Returns(GivenReadingResponse());

        // Act
        var response = await BuildSut().Get(_faker.Random.AlphaNumeric(5), _faker.Random.Int(1, 100));

        // Verify
        response.Should().NotBeNull();
        response.Readings.Should().HaveCount(1);
    }

    private ReadingResponse GivenReadingResponse()
    {
        return new()
        {
            Items = new List<Item>()
            {
                new()
                {
                    DateTime = DateTime.Now,
                    Value = _faker.Random.Decimal(),
                }
            }
        };
    }
    private RainfallManagementService BuildSut() => new (_floodMonitoringRepositoryFake.FakedObject,
        _mapperFake.FakedObject);
}