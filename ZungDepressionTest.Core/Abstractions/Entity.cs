namespace ZungDepressionTest.Core.Abstractions;

public abstract class Entity
{
    public Guid Id { get; init; }

    public Entity(Guid id)
    {
        Id = id;
    }

    public bool IsEqualById(Entity? entity)
    {
        if (entity is null)
            return false;

        return Id == entity.Id;
    }
}
