using ZungDepressionTest.Core.Entities.Question.Errors;
using ZungDepressionTest.Core.Tools;

namespace ZungDepressionTest.Core.Entities.Question.ValueObjects;

public record ZungQuestionText
{
    public string Value { get; init; }

    private ZungQuestionText(string value)
    {
        Value = value;
    }

    public static Result<ZungQuestionText> Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return ZungQuestionErrors.ZungQuestionTextEmpty;
        }

        return new ZungQuestionText(value);
    }
}