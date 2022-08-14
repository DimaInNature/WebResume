namespace WR.Shared.Domain.Features;

public abstract record class BaseAuthorizedFeature
{
    public string? Token { get; set; } = default;
}