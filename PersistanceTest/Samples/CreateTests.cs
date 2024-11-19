using NUnit.Framework.Internal;
using ZungDepressionTest.Application.Abstractions.Repositories;
using ZungDepressionTest.Core.Abstractions;
using ZungDepressionTest.Core.Entities;
using ZungDepressionTest.Core.Factories;
using ZungDepressionTest.Persistance.MySql.Repositories.QuestionsRepository.Models;
using ZungDepressionTest.Persistance.MySql.Repositories.QuestionStackRepository;

namespace PersistanceTest.Samples;

public class CreateTests
{
    [Test]
    public async Task TestCreate()
    {
        IQuestionsFactory questionsFactory = new QuestionFactory();
        var question = questionsFactory.Create("Вкусный Роллтон?", "Обратный");
        IQuestionRepository questionRepository = new QuestionsRepository();
        await questionRepository.InsertQuestionsAsync(question.Value);
        Assert.That(await questionRepository.GetQuestionsCountAsync(), Is.EqualTo(1));
    }

    [Test]
    public async Task StackCrate()
    {
        IQuestionStackRepository questionsFactory = new QuestionsStackRepository();
        QuestionsStack questionsStack = new QuestionsStack(Guid.NewGuid());
        await questionsFactory.SaveQuestionStack(questionsStack);
        Assert.That(await questionsFactory.Count(), Is.EqualTo(1));
    }
}
