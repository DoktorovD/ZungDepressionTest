using System.Text;
using ZungDepressionTest.Core.Abstractions;

namespace ZungDepressionTest.Core.Entities;

// Тип вопроса
public enum QuestionType
{
    Прямой,
    Обратный,
}

// Ответ на вопрос
public enum Answer
{
    Пустой,
    Первый,
    Второй,
    Третий,
    Четвертый,
}

// Класс вопроса
public sealed class Question : Entity
{
    // Текст вопроса
    public string Text { get; init; }

    // Тип вопроса
    public QuestionType Type { get; init; }

    // Ответ на вопрос (по умолчанию пустой)
    public Answer Answer { get; private set; }

    public QuestionsStack Stack { get; init; }

    // Конструктор создания вопроса (закрытый)
    internal Question(QuestionsStack stack, string text, QuestionType type)
        : base(Guid.NewGuid())
    {
        Stack = stack;
        Text = text;
        Type = type;
        Answer = Answer.Пустой;
    }

    // Метод присваивания вопроса
    public void SetAnswer(Answer answer)
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
