using LiteDB;
using ZungDepressionTest.Core.Entities;
using ZungDepressionTest.Persistance.MySql.Repositories.QuestionsRepository.Models;

namespace ZungDepressionTest.Persistance.MySql.Repositories.QuestionStackRepository;

public class QuestionStackDAO
{
    public Guid Id { get; set; }

    [BsonRef("Questions")]
    public List<QuestionDAO> Questions { get; set; } = new List<QuestionDAO>();
}

public static class QuestionStackDAOExtensions
{
    public static QuestionStackDAO Convert(this QuestionsStack questionStack)
    {
        QuestionStackDAO questionStackDAO = new QuestionStackDAO();
        questionStackDAO.Id = questionStack.Id;
        var questions = questionStack.Questions.GetAllQuestions();
        questionStackDAO.Questions = questions.Select(x => x.ToQuestionDAO()).ToList();
        return questionStackDAO;
    }
}
