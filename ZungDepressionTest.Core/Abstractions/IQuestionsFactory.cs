using ZungDepressionTest.Core.Entities;
using ZungDepressionTest.Core.Entities.Question;
using ZungDepressionTest.Core.Entities.QuestionStack;
using ZungDepressionTest.Core.Tools;

namespace ZungDepressionTest.Core.Abstractions;

public interface QuestionsFactory
{
    Result<Question> Create(QuestionsStack stack, string? text, string? type);
}
