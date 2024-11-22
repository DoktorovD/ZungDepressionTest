using NUnit.Framework.Internal;
using ZungDepressionTest.Core.Entities;
using ZungDepressionTest.Persistance.MySql.Repositories.QuestionStackRepository;

namespace PersistanceTest.Samples;

public class StackDelitionTest
{
    [Test]
    public async Task DeleteTest()
    {
        QuestionsStack stack = new QuestionsStack();
        QuestionsStackRepository stackRepository = new QuestionsStackRepository();
        await stackRepository.SaveQuestionStack(stack);
        await stackRepository.RemoveQuestionStack(stack);
        Assert.That(await stackRepository.Count(),Is.EqualTo(1));
    }
}