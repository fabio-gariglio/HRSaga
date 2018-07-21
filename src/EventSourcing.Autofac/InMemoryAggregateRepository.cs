namespace EventSourcing.Autofac
{
    public class InMemoryAggregateRepository<TAggregate> : IAggregateRepository<TAggregate>
        where TAggregate : Aggregate
    {
        public TAggregate GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(TAggregate aggregate)
        {
            throw new System.NotImplementedException();
        }
    }
}