using System.Text;
using ZungDepressionTest.Core.Abstractions;
using ZungDepressionTest.Core.Entities.Question.ValueObjects;

namespace ZungDepressionTest.Core.Entities.Question;

// Класс вопроса
public sealed class Question : Entity
{
    public ZungQuestionAnswer Answer = ZungQuestionAnswer.Create(0);
    public ZungQuestionText Text { get; private set; }
    public ZungQuestionType Type { get; private set; }

    public QuestionsStack Stack { get; init; }

    // Конструктор создания вопроса (закрытый)
    internal Question(QuestionsStack stack, ZungQuestionText text, ZungQuestionType type)
        : base(Guid.NewGuid())
    {
        Stack = stack;
        Text = text;
        Type = type;
    }

    // Метод присваивания вопроса
    public void SetAnswer(ZungQuestionAnswer answer)
    {
        Answer = answer;
    }

    // Метод отображения данных о вопросе в виде строки
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"ID: {Id}");
        builder.AppendLine($"Text: {Text}");
        builder.AppendLine($"Type: {Type}");
        builder.AppendLine($"Answer: {Answer}");
        return builder.ToString();
    }

    // Метод сравнения двух вопросов. Сравнение идёт по типу и тексту.
    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (obj is not Question question)
            return false;

        return question.Text == Text && question.Type == Type;
    }

    // Получение хэшкода вопроса по сумме кодов текста и типа.
    public override int GetHashCode()
    {
        return Text.GetHashCode() + Type.GetHashCode();
    }
}
