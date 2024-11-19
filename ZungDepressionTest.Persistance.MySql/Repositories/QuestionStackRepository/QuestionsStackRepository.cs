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
            col.Insert(stack);
        }
    }

    public Task RemoveQuestionStack(QuestionsStack stack)
    {
        throw new NotImplementedException();
    }

    public Task<QuestionsStack?> GetQuestionStackById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<QuestionsStack>> GetAllQuestionStacks()
    {
        throw new NotImplementedException();
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
