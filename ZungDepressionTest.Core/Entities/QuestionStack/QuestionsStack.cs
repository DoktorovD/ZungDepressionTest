using ZungDepressionTest.Core.Abstractions;
using ZungDepressionTest.Core.Entities.Question.ValueObjects;
using ZungDepressionTest.Core.Tools;

namespace ZungDepressionTest.Core.Entities;

// Стэк вопросов
public sealed class QuestionsStack : Entity
{
    private List<Question.Question> questionlist = new List<Question.Question>();

    public IReadOnlyList<Question.Question> QuestionList => questionlist;
    // Конструктор создания стэка вопросов
    public QuestionsStack()
        : base(Guid.NewGuid())
    {
       
    }

    public Result<Question.Question>AddQuestion(ZungQuestionText zungQuestionText,ZungQuestionType zungQuestionType)
    {
        Question.Question question = new Question.Question(this, zungQuestionText, zungQuestionType);
        if (HasThisQuestion(r => question.Text == r.Text))
        {
            return new Error("Этот вопрос уже есть в этом стэке!");
        }
        return question;
    }

    private bool HasThisQuestion(Func<Question.Question,bool> func)
    {
        return questionlist.Any(func);
    }

    public Result<Question.Question> DeleteQuestion(Question.Question question)
    {
        bool result = questionlist.Remove(question);
        if (result == false)
        {
            return new Error("Элемент не найден!");
        }
        return question;
    }

    public Result<Question.Question> FindQuestion(Func<Question.Question, bool> func)
    {
        Question.Question? result = questionlist.FirstOrDefault(func);
        if (result == null)
        {
            return new Error("Элемент не найден!");
        }
        return result;
    }
}
