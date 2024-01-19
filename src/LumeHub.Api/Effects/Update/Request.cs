﻿namespace LumeHub.Api.Effects.Update;

public sealed class Request
{
    [QueryParam]
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Data { get; init; }
}