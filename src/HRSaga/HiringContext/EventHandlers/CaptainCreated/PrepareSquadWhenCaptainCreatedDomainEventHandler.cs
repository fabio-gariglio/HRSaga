using EventSourcing;
using HRSaga.HiringContext.Aggregates;
using HRSaga.UnknownContext.Events;

namespace HRSaga.HiringContext.EventHandlers.CaptainCreated
{
    public class PrepareSquadWhenCaptainCreatedDomainEventHandler : IEventHandler<CaptainCreatedEvent>
    {
        private readonly IAggregateRepository<Squad> _squadRepository;

        public PrepareSquadWhenCaptainCreatedDomainEventHandler(IAggregateRepository<Squad> squadRepository)
        {
            _squadRepository = squadRepository;
        }
        
        public void Handle(CaptainCreatedEvent @event)
        {
            var squad = new Squad(
                leaderId: @event.Id
            );
            
            _squadRepository.Save(squad);
        }
    }
}