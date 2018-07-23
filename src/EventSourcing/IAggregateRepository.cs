namespace EventSourcing
{
    public interface IAggregateRepository<TAggregate> where TAggregate : IAggregate
    {
        TAggregate GetById(string id);

        void Save(TAggregate aggregate);
    }
}