namespace WR.Consumers.Desktop.Application.Extensions;

public static class StringExtensions
{
    public static bool AllIsNotNullOrWhiteSpace(this string[] strings) =>
        strings.All(predicate: stroke => string.IsNullOrWhiteSpace(value: stroke) is false);

    public static bool AllIsNullOrWhiteSpace(this string[] strings) =>
        strings.All(predicate: stroke => string.IsNullOrWhiteSpace(value: stroke));
}