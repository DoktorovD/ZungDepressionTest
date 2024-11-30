using ZungDepressionTest.Core.Entities;
using ZungDepressionTest.Core.Entities.Question;
using ZungDepressionTest.Core.Tools;

namespace ZungDepressionTest.Core.Abstractions;

public interface IQuestionsFactory
{
    Result<Question> Create(QuestionsStack stack, string? text, string? type);
}
