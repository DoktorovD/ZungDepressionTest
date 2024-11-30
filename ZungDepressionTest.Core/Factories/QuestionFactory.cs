using ZungDepressionTest.Core.Abstractions;
using ZungDepressionTest.Core.Entities;
using ZungDepressionTest.Core.Entities.Question;
using ZungDepressionTest.Core.Tools;

namespace ZungDepressionTest.Core.Factories;

public sealed class QuestionFactory : IQuestionsFactory
{
    public Result<Question> Create(QuestionsStack stack, string? text, string? type)
    {
        if (string.IsNullOrWhiteSpace(text))
            return new Error("Текст вопроса была пустым");

        if (string.IsNullOrWhiteSpace(type))
            return new Error("Тип вопроса был пустым");

        bool isValid = Enum.TryParse(type, out QuestionType result);

        if (!isValid)
            return new Error("Недопустимый тип вопроса. Допустимы Прямой и Обратный");

        return new Question(stack, text, result);
    }
}
