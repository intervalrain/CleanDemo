namespace CleanDemo.Domain.Common;

public abstract class Entity
{
    public Guid Id { get; private set; }

    protected readonly List<IDomainEvent> _domainEvents = new();

    public Entity(Guid id)
    {
        Id = id;
    }

    public List<IDomainEvent> PopDomainEvents()
    {
        var copy = _domainEvents;
        _domainEvents.Clear();

        return copy;
    }

    protected Entity() { }
}

