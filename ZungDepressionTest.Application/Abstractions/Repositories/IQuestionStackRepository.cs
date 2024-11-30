using ZungDepressionTest.Core.Entities.QuestionStack;

namespace ZungDepressionTest.Application.Abstractions.Repositories;

public interface IQuestionStackRepository
{
    Task Add(QuestionsStack stack);
    Task Remove(QuestionsStack stack);
    Task<QuestionsStack?> GetById(Guid id);
    Task<IReadOnlyList<QuestionsStack>> GetAll();
    Task<int> GetCount();
}
