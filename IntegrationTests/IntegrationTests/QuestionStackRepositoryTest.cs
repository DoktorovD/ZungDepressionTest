using ZungDepressionTest.Application.Abstractions.Repositories;
using ZungDepressionTest.Core.Entities;
using ZungDepressionTest.Persistance.InMemoryDataBase;

namespace IntegrationTests.IntegrationTests;

public class QuestionStackRepositoryTest
{
    [Test()]
    public async Task SaveQuestionStack()
    {
        QuestionsStack stack = new QuestionsStack(Guid.NewGuid());
        IQuestionStackRepository repository = new InMemoryQuestionsStackRepository();
        await repository.SaveQuestionStack(stack);
        IReadOnlyList<QuestionsStack> stacks = await repository.GetAllQuestionStacks();
        Assert.That(stacks.Count, Is.EqualTo(1));
    }

    [Test()]
    public async Task RemoveQuestionStack()
    {
        QuestionsStack stack = new QuestionsStack(Guid.NewGuid());
        IQuestionStackRepository repository = new InMemoryQuestionsStackRepository();
        await repository.SaveQuestionStack(stack);
        await repository.RemoveQuestionStack(stack);
        IReadOnlyList<QuestionsStack> stacks = await repository.GetAllQuestionStacks();
        Assert.That(stacks.Count, Is.EqualTo(0));
    }

    [Test()]
    public async Task GetQuestionStackById()
    {
        QuestionsStack stack = new QuestionsStack(Guid.NewGuid());
        IQuestionStackRepository repository = new InMemoryQuestionsStackRepository();
        await repository.SaveQuestionStack(stack);
        stack = await repository.GetQuestionStackById(stack.Id);
        IReadOnlyList<QuestionsStack> stacks = await repository.GetAllQuestionStacks();
        Assert.That(stack.Id, Is.EqualTo(stack.Id));
    }
}
