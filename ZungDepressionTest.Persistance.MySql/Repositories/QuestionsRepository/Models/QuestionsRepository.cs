using LiteDB;
using ZungDepressionTest.Application.Abstractions.Repositories;
using ZungDepressionTest.Application.Tools;
using ZungDepressionTest.Core.Entities;

namespace ZungDepressionTest.Persistance.MySql.Repositories.QuestionsRepository.Models;

public sealed class QuestionsRepository : IQuestionRepository
{
    public async Task InsertQuestionsAsync(Question question)
    {
        using (var db = new LiteDatabase("MyData.db"))
        {
            var col = db.GetCollection<QuestionDAO>(Constants.ConnectionString);

            var questionDAO = new QuestionDAO();
            questionDAO.Text = question.Text;
            questionDAO.Answer = question.Answer.ConvertToBite();
            questionDAO.Id = question.Id;
            questionDAO.Type = question.Type.ToString();

            col.Insert(questionDAO);
        }
    }

    public async Task RemoveQuestionAsync(Question question)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetQuestionsCountAsync()
    {
        using (var db = new LiteDatabase("MyData.db"))
        {
            var col = db.GetCollection<QuestionDAO>("Questions");
            return col.Count();
        }
    }
}
