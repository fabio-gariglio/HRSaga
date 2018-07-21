namespace EventSourcing
{
    public interface IAggregateRepository<TAggregate> where TAggregate : Aggregate
    {
        TAggregate GetById(string id);

        void Save(TAggregate aggregate);
    }
}