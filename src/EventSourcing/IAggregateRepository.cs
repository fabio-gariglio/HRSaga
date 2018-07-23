namespace EventSourcing
{
    public interface IAggregateRepository<TAggregate>
        where TAggregate : IAggregate, new()
    {
        TAggregate GetById(string id);

        void Save(TAggregate aggregate);
    }
}