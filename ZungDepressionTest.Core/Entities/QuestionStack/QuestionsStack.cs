using ZungDepressionTest.Core.Abstractions;
using ZungDepressionTest.Core.Entities.Question.ValueObjects;
using ZungDepressionTest.Core.Tools;

namespace ZungDepressionTest.Core.Entities.QuestionStack;

public sealed class QuestionsStack(Guid id = default) : Entity(id == default ? Guid.NewGuid() : id)
{
    private readonly List<Question.Question> _questionsesList = [];
    public IReadOnlyList<Question.Question> QuestionsList => _questionsesList.ToList();

    public Result<Question.Question> AddQuestion(
        ZungQuestionText zungQuestionText,
        ZungQuestionType zungQuestionType
    )
    {
        var question = new Question.Question(this, zungQuestionText, zungQuestionType);
        if (HasThisQuestion(r => question.Text == r.Text))
            return new Error("Этот вопрос уже есть в этом стэке!");
        _questionsesList.Add(question);
        return question;
    }

    private bool HasThisQuestion(Func<Question.Question, bool> func) => _questionsesList.Any(func);

    public Result<Question.Question> DeleteQuestion(Question.Question question)
    {
        var result = _questionsesList.Remove(question);
        if (result == false)
            return new Error("Элемент не найден!");
        return question;
    }

    public Result<Question.Question> FindQuestion(Func<Question.Question, bool> func)
    {
        Question.Question? result = _questionsesList.FirstOrDefault(func);
        if (result == null)
            return new Error("Элемент не найден!");
        return result;
    }
}
