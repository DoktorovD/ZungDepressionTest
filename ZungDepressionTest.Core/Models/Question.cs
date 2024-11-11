using ZungDepressionTest.Core.Abstractions;

namespace ZungDepressionTest.Core.Models;

public class Question : Entity
{
    public QuestionAnswer Answer { get; private set; }
    public string Text { get; init; }
    public QuestionStack Stack { get; init; }
    public QuestionType Type { get; init; }

    private Question(Guid id, QuestionStack stack, string text, QuestionType type)
        : base(id)
    {
        Stack = stack;
        Text = text;
        Type = type;
        Answer = new EmptyQuestionAnswer();
    }

    public void GiveAnswer(QuestionAnswer answer)
    {
        Answer = answer;
    }
}
