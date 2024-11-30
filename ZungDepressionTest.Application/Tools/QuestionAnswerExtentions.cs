using ZungDepressionTest.Core.Entities;
using ZungDepressionTest.Core.Entities.Question;

namespace ZungDepressionTest.Application.Tools;

public static class QuestionAnswerExtentions
{
    public static byte ConvertToBite(this Answer questionAnswer)
    {
        return questionAnswer switch
        {
            Answer.Пустой => 0,
            Answer.Первый => 1,
            Answer.Второй => 2,
            Answer.Третий => 3,
            Answer.Четвертый => 4,
            _ => 0,
        };
    }
}
