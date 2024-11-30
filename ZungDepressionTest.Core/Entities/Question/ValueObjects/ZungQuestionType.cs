using ZungDepressionTest.Core.Entities.Question.Errors;
using ZungDepressionTest.Core.Tools;

namespace ZungDepressionTest.Core.Entities.Question.ValueObjects;

public enum ZungQuestionTypes
{
    Прямой,
    Обратный
}

public record ZungQuestionType
{
    public ZungQuestionTypes Type { get; init; }

    private ZungQuestionType(ZungQuestionTypes type)
    {
        Type = type;
    }

    public static Result<ZungQuestionType> Create(string? text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return ZungQuestionErrors.ZungQuestionTypeEmpty;
        }

        bool IsValid = Enum.TryParse<ZungQuestionTypes>(text, true, out ZungQuestionTypes result);
        if (IsValid == false)
        {
            return ZungQuestionErrors.ZungQuestionInvalidType;
        }

        return new ZungQuestionType(result);
    }
}
