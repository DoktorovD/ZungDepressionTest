using System.Reflection.Metadata;
using LiteDB;
using ZungDepressionTest.Application.Abstractions.Repositories;
using ZungDepressionTest.Core.Entities;
using ZungDepressionTest.Core.Entities.Question;

namespace ZungDepressionTest.Persistance.MySql.Repositories.QuestionStackRepository;

public class QuestionsStackRepository : IQuestionStackRepository
{
    public async Task SaveQuestionStack(QuestionsStack stack)
    {
        using (var db = new LiteDatabase(Constants.ConnectionString))
        {
            var col = db.GetCollection<QuestionsStack>();
            col.EnsureIndex(i => i.Id);
            col.Insert(stack);
        }
    }

    public async Task RemoveQuestionStack(QuestionsStack stack)
    {
        using (var db = new LiteDatabase(Constants.ConnectionString))
        {
            var col = db.GetCollection<QuestionsStack>();
            col.EnsureIndex(i => i.Id);
            col.Delete(stack.Id);
        }
    }

    public async Task<QuestionsStack?> GetQuestionStackById(Guid id)
    {
        using (var db = new LiteDatabase(Constants.ConnectionString))
        {
            var col = db.GetCollection<QuestionsStack>();
            return col.FindById(id);
        }
    }

    public async Task<IReadOnlyList<QuestionsStack>> GetAllQuestionStacks()
    {
        using (var db = new LiteDatabase(Constants.ConnectionString))
        {
            var col = db.GetCollection<QuestionsStack>();
            col.EnsureIndex(x => x.Id);
            return col.Include(x => x.QuestionList).FindAll().ToList();
        }
        
    }

    public async Task<int> Count()
    {
        using (var db = new LiteDatabase(Constants.ConnectionString))
        {
            var col = db.GetCollection<QuestionsStack>();
            return col.Count();
        }
    }
}
