using LiteDB.Async;
using ZungDepressionTest.Application.Abstractions.Repositories;
using ZungDepressionTest.Core.Entities.Question;

namespace ZungDepressionTest.Persistance.Repositories.QuestionsRepository.Models;

public sealed class QuestionsRepository : IQuestionRepository
{
    public async Task Add(Question question)
    {
        using LiteDatabaseAsync db = new LiteDatabaseAsync(Constants.ConnectionString);
        var col = db.GetCollection<Question>(Constants.Questions);
        await col.EnsureIndexAsync(i => i.Id);
        await col.InsertAsync(question);
    }

    public async Task Remove(Question question)
    {
        using LiteDatabaseAsync db = new LiteDatabaseAsync(Constants.ConnectionString);
        var col = db.GetCollection<Question>(Constants.Questions);
        await col.EnsureIndexAsync(i => i.Id);
        await col.DeleteAsync(question.Id);
    }

    public async Task<int> GetCount()
    {
        using LiteDatabaseAsync db = new LiteDatabaseAsync(Constants.ConnectionString);
        var col = db.GetCollection<Question>(Constants.Questions);
        return await col.CountAsync();
    }
}
