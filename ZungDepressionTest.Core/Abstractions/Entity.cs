namespace ZungDepressionTest.Core.Abstractions;

public abstract class Entity(Guid id)
{
    public Guid Id { get; init; } = id;

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (obj is not Entity other)
        {
            return false;
        }
        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

}