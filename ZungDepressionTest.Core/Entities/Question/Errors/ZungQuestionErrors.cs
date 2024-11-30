using ZungDepressionTest.Core.Tools;

namespace ZungDepressionTest.Core.Entities.Question.Errors;

public static class ZungQuestionErrors
{
    public static readonly Error ZungQuestionTextEmpty = new Error("Пустой текст вопроса!");
    public static readonly Error ZungQuestionTypeEmpty = new Error("Пустой тип вопроса!");
    public static readonly Error ZungQuestionInvalidType = new Error("Неверный тип вопроса!");
    public static readonly Error ZungQuestionInvalidAnswer = new Error("Недопустимый ответ на вопрос!");
}