using ZungDepressionTest.Core.Entities;
using ZungDepressionTest.Core.Entities.Question;

namespace ZungDepressionTest.Application.Abstractions.Repositories;

public interface IQuestionRepository
{
    Task InsertQuestionsAsync(Question question);
    Task RemoveQuestionAsync(Question question);
    Task<int> GetQuestionsCountAsync();
}
