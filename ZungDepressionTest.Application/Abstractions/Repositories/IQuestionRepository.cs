using ZungDepressionTest.Core.Entities.Question;

namespace ZungDepressionTest.Application.Abstractions.Repositories;

public interface IQuestionRepository
{
    Task Add(Question question);
    Task Remove(Question question);
    Task<int> GetCount();
}
