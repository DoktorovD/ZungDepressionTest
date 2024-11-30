using LiteDB;
using ZungDepressionTest.Application.Abstractions.Repositories;
using ZungDepressionTest.Core.Entities.Question;

namespace ZungDepressionTest.Persistance.MySql.Repositories.QuestionsRepository.Models;

public sealed class QuestionsRepository : IQuestionRepository
{
    public async Task InsertQuestionsAsync(Question question)
    {
        using (var db = new LiteDatabase("MyData.db"))
        {
            var col = db.GetCollection<Question>(Constants.ConnectionString);
            col.EnsureIndex(i => i.Id);
            col.Insert(question);
        }
    }

    public async Task RemoveQuestionAsync(Question question)
    {
        using (var db = new LiteDatabase("MyData.db"))
        {
            var col = db.GetCollection<Question>(Constants.ConnectionString);
            col.EnsureIndex(i => i.Id);
            col.Delete(question.Id);
        }
    }

    public async Task<int> GetQuestionsCountAsync()
    {
        using (var db = new LiteDatabase("MyData.db"))
        {
            var col = db.GetCollection<Question>(Constants.ConnectionString);
            return col.Count();
        }
    }
}
