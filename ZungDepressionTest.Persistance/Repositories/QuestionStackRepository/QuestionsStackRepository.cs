using LiteDB;
using LiteDB.Async;
using ZungDepressionTest.Application.Abstractions.Repositories;
using ZungDepressionTest.Core.Entities.QuestionStack;

namespace ZungDepressionTest.Persistance.Repositories.QuestionStackRepository;

public class QuestionsStackRepository : IQuestionStackRepository
{
    public QuestionsStackRepository()
    {
        BsonMapper.Global.IncludeFields = true;
        BsonMapper.Global.Entity<QuestionsStack>().DbRef(x => x.QuestionsList, "Questions");
    }

    public async Task Add(QuestionsStack stack)
    {
        using LiteDatabaseAsync db = new LiteDatabaseAsync(Constants.ConnectionString);
        var col = db.GetCollection<QuestionsStack>(Constants.QuestionStacks);
        await col.EnsureIndexAsync(i => i.Id);
        await col.InsertAsync(stack);
    }

    public async Task Remove(QuestionsStack stack)
    {
        using LiteDatabaseAsync db = new LiteDatabaseAsync(Constants.ConnectionString);
        var col = db.GetCollection<QuestionsStack>(Constants.QuestionStacks);
        await col.EnsureIndexAsync(i => i.Id);
        await col.DeleteAsync(stack.Id);
    }

    public async Task<QuestionsStack?> GetById(Guid id)
    {
        using LiteDatabaseAsync db = new LiteDatabaseAsync(Constants.ConnectionString);
        var col = db.GetCollection<QuestionsStack>(Constants.QuestionStacks);
        return await col.Include(s => s.QuestionsList).FindByIdAsync(id);
    }

    public async Task<IReadOnlyList<QuestionsStack>> GetAll()
    {
        using LiteDatabaseAsync db = new LiteDatabaseAsync(Constants.ConnectionString);
        var col = db.GetCollection<QuestionsStack>(Constants.QuestionStacks);
        await col.EnsureIndexAsync(x => x.Id);
        var items = await col.Include(x => x.QuestionsList).FindAllAsync();
        return items.ToList();
    }

    public async Task<int> GetCount()
    {
        using LiteDatabaseAsync db = new LiteDatabaseAsync(Constants.ConnectionString);
        var col = db.GetCollection<QuestionsStack>(Constants.QuestionStacks);
        return await col.CountAsync();
    }
}
