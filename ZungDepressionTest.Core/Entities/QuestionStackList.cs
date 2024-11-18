using ZungDepressionTest.Core.Tools;

namespace ZungDepressionTest.Core.Entities;

public sealed class QuestionStackList
{
    private readonly List<Question> _questions = [];

    // Метод добавления вопроса в стэк вопросов
    public Result<Question> AddQuestion(Question question)
    {
        // Если стэк уже имеет вопрос, выдаем ошибку о дубликате
        if (_questions.Any(q => q.Equals(question)))
            return new Error("Такой вопрос уже есть в этом наборе вопросов");

        // Если все хорошо, то добавляем вопрос в список вопросов и возвращаем добавленный вопрос
        _questions.Add(question);
        return question;
    }

    // Метод удаления вопроса из стека
    public Result<Question> RemoveQuestion(Question question)
    {
        // Запрашиваем вопрос в списке вопросов
        Question? requested = _questions.FirstOrDefault(q => q.Equals(question));

        // Если вопрос не найден - возвращаем ошибку
        if (requested is null)
            return new Error("Вопрос не найден");

        // Если вопрос найден, то удаляем его из списка и возвращаем удаленный вопрос
        _questions.Remove(requested);
        return requested;
    }

    // Метод запрашивания вопроса из стека вопросов
    public Result<Question> GetQuestion(Func<Question, bool> expression)
    {
        // Ищем вопрос по выражению
        Question? requested = _questions.FirstOrDefault(expression);

        // Возвращаем ошибку если не найден, и найденный вопрос если найден
        return requested is null ? new Error("Вопрос не найден") : requested;
    }

    // Метод получения всех вопросов.
    public IReadOnlyList<Question> GetAllQuestions()
    {
        return _questions.ToList();
    }
}
