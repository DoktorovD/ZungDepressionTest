using ZungDepressionTest.Core.Entities;
using ZungDepressionTest.Core.Tools;

namespace ZungDepressionTest.Core.Abstractions;

public interface IQuestionsFactory
{
    Result<Question> Create(string? text, string? type);
}
