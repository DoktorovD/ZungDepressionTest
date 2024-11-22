using NUnit.Framework.Internal;
using ZungDepressionTest.Core.Entities;
using ZungDepressionTest.Persistance.MySql.Repositories.QuestionStackRepository;

namespace PersistanceTest.Samples;

public class FindById
{
    [Test]
    public async Task GetAll()
    {
        QuestionsStackRepository questionsStackRepository = new QuestionsStackRepository();
        var list = await questionsStackRepository.GetAllQuestionStacks();
        Assert.That(list.Count,Is.EqualTo(await questionsStackRepository.Count()));
    }
}