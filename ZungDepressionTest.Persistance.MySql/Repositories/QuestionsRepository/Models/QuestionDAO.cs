using ZungDepressionTest.Application.Tools;
using ZungDepressionTest.Core.Entities;

namespace ZungDepressionTest.Persistance.MySql.Repositories.QuestionsRepository.Models;

public sealed class QuestionDAO
{
    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public byte Answer { get; set; }
    public string Type { get; set; } = string.Empty;
}

public static class QuestionDAOExtensions
{
    public static QuestionDAO ToQuestionDAO(this Question question)
    {
        var questionDAO = new QuestionDAO();
        questionDAO.Text = question.Text;
        questionDAO.Answer = question.Answer.ConvertToBite();
        questionDAO.Id = question.Id;
        questionDAO.Type = question.Type.ToString();
        return questionDAO;
    }
}
