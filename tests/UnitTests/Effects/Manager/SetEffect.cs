﻿using LumeHub.Api.Effects;
using LumeHub.Core.Colors;
using LumeHub.Core.Effects.Normal;
using LumeHub.Core.LedControl;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace UnitTests.Effects.Manager;
public sealed class SetEffect
{
    [Fact]
    public void CurrentEffectGetsUpdate_When_FirstEffectIsApplied()
    {
        // Arrange
        var ledController = Substitute.For<LedController>(Options.Create(new LedControllerOptions{ PixelCount = 100 }));
        ledController.SetAllPixel(new RgbColor());
        var manager = new LumeHub.Api.Effects.Manager(ledController);
        var effect = new EffectDto
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Test",
            Data = JsonSerializer.Serialize(new FadeColor{ Color = new RgbColor(123, 45 ,6)})
        };

        // Act
        manager.SetEffect(effect);

        // Assert
        manager.CurrentEffect.Should().BeEquivalentTo(effect);
    }
}