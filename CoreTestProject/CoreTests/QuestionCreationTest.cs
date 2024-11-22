using System.Diagnostics;
using ZungDepressionTest.Core.Abstractions;
using ZungDepressionTest.Core.Entities;
using ZungDepressionTest.Core.Factories;
using ZungDepressionTest.Core.Tools;

namespace CoreTestProject.CoreTests;

public class QuestionCreationTest
{
    [Test()]
    public void CreateQuestionTest()
    {
        
        IQuestionsFactory factory = new QuestionFactory();
        QuestionsStack questionsStack = new QuestionsStack();
        Result<Question> question = factory.Create(questionsStack,"Как заварить ролтон", "Прямой");
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.WriteLine(question.Value.ToString());
        Assert.That(question.IsOk, Is.EqualTo(true));
    }

    [Test()]
    public void CreateInvalidQuestionTest()
    {
        IQuestionsFactory factory = new QuestionFactory();
        QuestionsStack questionsStack = new QuestionsStack();
        Result<Question> question = factory.Create(questionsStack,"" ,"Хабиб");
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.WriteLine(question.Error.Message);
        Assert.That(question.IsOk, Is.EqualTo(false));
    }

    [Test()]
    public void AddQuestionInStackTest()
    {
        IQuestionsFactory factory = new QuestionFactory();
        QuestionsStack questionsStack = new QuestionsStack();
        Result<Question> question = factory.Create(questionsStack,"Как заварить ролтон", "Прямой");
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.WriteLine(question.Value.ToString());
        question = questionsStack.Questions.AddQuestion(question.Value);
        Assert.That(question.IsOk, Is.EqualTo(true));
    }

    [Test()]
    public void RemoveQuestionFromStackTest()
    {
        IQuestionsFactory factory = new QuestionFactory();
        QuestionsStack questionsStack = new QuestionsStack();
        Result<Question> question = factory.Create(questionsStack,"Как заварить ролтон", "Прямой");
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.WriteLine(question.Value.ToString());
        question = questionsStack.Questions.AddQuestion(question.Value);
        question = questionsStack.Questions.RemoveQuestion(question.Value);
        Assert.That(question.IsOk, Is.EqualTo(true));
    }

    [Test()]
    public void FindQuestionFromStackTest()
    {
        IQuestionsFactory factory = new QuestionFactory();
        QuestionsStack questionsStack = new QuestionsStack();
        Result<Question> question = factory.Create(questionsStack,"Как заварить ролтон" ,"Прямой");
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.WriteLine(question.Value.ToString());
        question = questionsStack.Questions.AddQuestion(question.Value);
        question = questionsStack.Questions.GetQuestion(q => q.Text == "Как заварить ролтон");
        Assert.That(question.IsOk, Is.EqualTo(true));
    }
}
