using ZungDepressionTest.Core.Abstractions;

namespace ZungDepressionTest.Core.Entities;

// Стэк вопросов
public sealed class QuestionsStack : Entity
{
    // Класс содержащий список вопросов
    public QuestionStackList Questions { get; init; }

    // Конструктор создания стэка вопросов
    public QuestionsStack(Guid id)
        : base(id)
    {
        Questions = new QuestionStackList();
    }
}
