using ZungDepressionTest.Core.Entities.Question.Errors;
using ZungDepressionTest.Core.Tools;

namespace ZungDepressionTest.Core.Entities.Question.ValueObjects;

public enum ZungQuestionAnswers
{
    Пустой = 0,
    Первый = 1,
    Второй = 2,
    Третий = 3,
    Четвёртый = 4
}

public record ZungQuestionAnswer
{
    public ZungQuestionAnswers Answer { get; init; }

    private ZungQuestionAnswer(ZungQuestionAnswers answer)
    {
        Answer = answer;
    }

    public static Result<ZungQuestionAnswer> Create(int? ans)
    {
        if (ans == null)
        {
            ZungQuestionAnswer answer = new ZungQuestionAnswer(ZungQuestionAnswers.Пустой);
            return answer;
        }

        if (ans > 4)
        {
            return ZungQuestionErrors.ZungQuestionInvalidAnswer;
        }

        return new ZungQuestionAnswer((ZungQuestionAnswers)ans);
    }
}