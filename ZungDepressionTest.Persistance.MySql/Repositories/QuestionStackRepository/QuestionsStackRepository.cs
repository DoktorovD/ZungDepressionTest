using System.Reflection.Metadata;
using LiteDB;
using ZungDepressionTest.Application.Abstractions.Repositories;
using ZungDepressionTest.Core.Entities;

namespace ZungDepressionTest.Persistance.MySql.Repositories.QuestionStackRepository;

public class QuestionsStackRepository : IQuestionStackRepository
{
    public async Task SaveQuestionStack(QuestionsStack stack)
    {
        using (var db = new LiteDatabase(Constants.ConnectionString))
        {
            var col = db.GetCollection<QuestionsStack>();

            QuestionStackDAO dao = stack.Convert();
            col.EnsureIndex(i => i.Id);
            col.Insert(stack);
        }
    }

    public async Task RemoveQuestionStack(QuestionsStack stack)
    {
        using (var db = new LiteDatabase(Constants.ConnectionString))
        {
            var col = db.GetCollection<QuestionsStack>();

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
            return col.Include(i => i.Questions.GetAllQuestions()).FindAll().ToList();
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
