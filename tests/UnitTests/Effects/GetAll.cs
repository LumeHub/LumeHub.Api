﻿using LumeHub.Api.Effects;
using LumeHub.Api.Effects.GetAll;

namespace UnitTests.Effects;

public sealed class GetAll
{
    [Fact]
    public async void ReturnsEmptyList()
    {
        // Arrange
        var repository = Substitute.For<IRepository>();
        repository.GetAll().Returns([]);

        var endpoint = Factory.Create<Endpoint>(repository);
        endpoint.Map = new Mapper();

        // Act
        await endpoint.HandleAsync(default);

        // Assert
        endpoint.Response.Effects.Should().BeEmpty();
    }

    [Fact]
    public async void ReturnsTwoEffects()
    {
        // Arrange
        List<EffectDto> effects =
        [
            new EffectDto { Id = "1", Name = "Name", Data = "Data" },
            new EffectDto { Id = "2", Name = "Other", Data = "OtherData" }
        ];

        var repository = Substitute.For<IRepository>();
        repository.GetAll().Returns(effects);

        var endpoint = Factory.Create<Endpoint>(repository);
        endpoint.Map = new Mapper();

        // Act
        await endpoint.HandleAsync(default);

        // Arrange
        endpoint.Response.Effects.Should().HaveCount(2);
        endpoint.Response.Effects.Should().BeEquivalentTo(effects);
    }
}