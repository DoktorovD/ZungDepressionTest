using ZungDepressionTest.Core.Abstractions;

namespace ZungDepressionTest.Core.Models;

public sealed class QuestionStack : AggregateRoot
{
    public int StackSize { get; init; }

    private QuestionStack(Guid id,int stackSize) : base(id)
    {
        StackSize = stackSize;
    }
}