namespace ZungDepressionTest.Core.Helpers;

public record Error(string Description)
{
    public static Error None = new(string.Empty);
}
