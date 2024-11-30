using ZungDepressionTest.Core.Abstractions;
using ZungDepressionTest.Core.Entities.Question.ValueObjects;
using ZungDepressionTest.Core.Entities.QuestionStack;

namespace ZungDepressionTest.Core.Entities.Question;

public sealed class Question : Entity
{
    public ZungQuestionAnswer Answer = ZungQuestionAnswer.Create(0);
    public ZungQuestionText Text { get; private set; }
    public ZungQuestionType Type { get; private set; }
    public QuestionsStack Stack { get; init; }

    internal Question(
        QuestionsStack stack,
        ZungQuestionText text,
        ZungQuestionType type,
        Guid id = default
    )
        : base(id == default ? Guid.NewGuid() : id)
    {
        Stack = stack;
        Text = text;
        Type = type;
    }

    public void SetAnswer(ZungQuestionAnswer answer) => Answer = answer;
}
