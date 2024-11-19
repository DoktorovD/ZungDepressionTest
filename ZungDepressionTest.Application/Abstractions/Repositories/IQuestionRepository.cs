using ZungDepressionTest.Core.Entities;

namespace ZungDepressionTest.Application.Abstractions.Repositories;

public interface IQuestionRepository
{
    Task InsertQuestionsAsync(Question question);
    Task RemoveQuestionAsync(Question question);
    Task<int> GetQuestionsCountAsync();
}
