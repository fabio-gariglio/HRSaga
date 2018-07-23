using EventSourcing;
using HRSaga.HiringContext.Aggregates;
using HRSaga.UnknownContext.DomainEvents;

namespace HRSaga.HiringContext.EventHandlers
{
    public class CreateSquadWhenCaptainCreatedDomainEvent : IEventHandler<CaptainCreatedDomainEvent>
    {
        private readonly IAggregateRepository<Squad> _squadRepository;

        public CreateSquadWhenCaptainCreatedDomainEvent(IAggregateRepository<Squad> squadRepository)
        {
            _squadRepository = squadRepository;
        }
        
        public void Handle(CaptainCreatedDomainEvent @event)
        {
            var squad = new Squad(@event.CaptainId);
            
            _squadRepository.Save(squad);
        }
    }
}