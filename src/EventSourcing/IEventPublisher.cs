namespace EventSourcing
{
    public interface IEventPublisher
    {
        void Publish(IEvent @event);
    }
}