using ZungDepressionTest.Application.Abstractions.Repositories;
using ZungDepressionTest.Core.Entities.Question;
using ZungDepressionTest.Core.Entities.Question.ValueObjects;
using ZungDepressionTest.Core.Entities.QuestionStack;
using ZungDepressionTest.Persistance.Repositories.QuestionsRepository.Models;
using ZungDepressionTest.Persistance.Repositories.QuestionStackRepository;

namespace ZungDepressionTest.NUnitTests.QuestionStackTests;

[TestFixture]
public class QuestionStackTestSamples
{
    private readonly IQuestionStackRepository _stacksRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly QuestionsStack stack = new QuestionsStack();

    public QuestionStackTestSamples()
    {
        _stacksRepository = new QuestionsStackRepository();
        _questionRepository = new QuestionsRepository();
    }

    [Test(), Order(1)]
    public async Task ACreateQuestionStackTest()
    {
        await _stacksRepository.Add(stack);
        var check = await _stacksRepository.GetById(stack.Id);
        Assert.That(check, Is.Not.Null);
    }

    [Test(), Order(2)]
    public async Task BInsertQuestionToStack()
    {
        ZungQuestionText text = ZungQuestionText.Create("Тестовый вопрос");
        ZungQuestionType type = ZungQuestionType.Create("Прямой");
        Question question = stack.AddQuestion(text, type);
        await _questionRepository.Add(question);
        var check = await _stacksRepository.GetById(stack.Id);
        if (check == null)
        {
            Assert.Fail();
            return;
        }

        var checkQuestion = check.FindQuestion(q => q.Id == question.Id);
        Assert.That(checkQuestion, Is.Not.Null);
    }

    [Test(), Order(3)]
    public async Task CRemoveQuestionStackTest()
    {
        var savedStack = await _stacksRepository.GetById(stack.Id);
        if (savedStack == null)
        {
            Assert.Pass();
            return;
        }

        await _stacksRepository.Remove(savedStack);
        var check = await _stacksRepository.GetById(stack.Id);
        Assert.That(check, Is.Null);
    }
}
