﻿using LumeHub.Core.Effects;

namespace LumeHub.Api.Effects;

public class EffectDto
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; }
    public required string Data { get; set; }

    public static implicit operator Effect?(EffectDto dto)
    {
        EffectUtils.TryConvert(dto.Data, out var effect);
        return effect;
    }
}