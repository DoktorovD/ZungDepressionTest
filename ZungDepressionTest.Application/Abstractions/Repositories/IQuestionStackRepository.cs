using ZungDepressionTest.Core.Entities;

namespace ZungDepressionTest.Application.Abstractions.Repositories;

public interface IQuestionStackRepository
{
    Task SaveQuestionStack(QuestionsStack stack);
    Task RemoveQuestionStack(QuestionsStack stack);
    Task<QuestionsStack?> GetQuestionStackById(Guid id);
    Task<IReadOnlyList<QuestionsStack>> GetAllQuestionStacks();
    Task<int> Count();
}
