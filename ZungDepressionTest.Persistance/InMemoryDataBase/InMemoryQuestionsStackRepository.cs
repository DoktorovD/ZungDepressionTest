using ZungDepressionTest.Application.Abstractions.Repositories;
using ZungDepressionTest.Core.Entities;

namespace ZungDepressionTest.Persistance.InMemoryDataBase;

public sealed class InMemoryQuestionsStackRepository : IQuestionStackRepository
{
    private readonly List<QuestionsStack> _questionsStacks = [];

    public async Task SaveQuestionStack(QuestionsStack stack)
    {
        _questionsStacks.Add(stack);
        await Task.CompletedTask;
    }

    public async Task RemoveQuestionStack(QuestionsStack stack)
    {
        _questionsStacks.Remove(stack);
        await Task.CompletedTask;
    }

    public async Task<QuestionsStack?> GetQuestionStackById(Guid id)
    {
        return await Task.FromResult(_questionsStacks.FirstOrDefault(q => q.Id == id));
    }

    public async Task<IReadOnlyList<QuestionsStack>> GetAllQuestionStacks()
    {
        return await Task.FromResult(_questionsStacks);
    }

    public async Task<int> Count()
    {
        return await Task.FromResult(_questionsStacks.Count);
    }
}
