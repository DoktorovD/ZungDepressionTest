using ZungDepressionTest.Core.Abstractions;
using ZungDepressionTest.Core.Helpers;

namespace ZungDepressionTest.Core.Models;

public class QuestionStackList : CustomList<Question>
{
    public override Result<Question> Add(Question item)
    {
        throw new NotImplementedException();
    }

    public override Result<Question> Remove(Question item)
    {
        throw new NotImplementedException();
    }

    public override Result<Question> Find(Func<Question, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public override IReadOnlyList<Question> GetItems(Func<Question, bool> predicate)
    {
        throw new NotImplementedException();
    }
}
