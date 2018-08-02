using EventSourcing;
using HRSaga.GameContext.DomainEvents;

namespace HRSaga.HiringContext.EventHandlers
{
    public class PopulationProjection :
        IEventHandler<CaptainCreatedDomainEvent>,
        IEventHandler<WarriorCreatedDomainEvent>,
        IEventHandler<WizardCreatedDomainEvent>
    {
        private readonly IPopulationService _populationService;

        public PopulationProjection(IPopulationService populationService)
        {
            _populationService = populationService;
        }
        
        public void Handle(CaptainCreatedDomainEvent @event)
        {
            _populationService.AddCreature(new CreatureModel
            {
                Id = @event.CaptainId,
                Type = CreatureType.Captain
            });
        }

        public void Handle(WarriorCreatedDomainEvent @event)
        {
            _populationService.AddCreature(new CreatureModel
            {
                Id = @event.WarriorId,
                Type = CreatureType.Warrior
            });
        }

        public void Handle(WizardCreatedDomainEvent @event)
        {
            _populationService.AddCreature(new CreatureModel
            {
                Id = @event.WizardId,
                Type = CreatureType.Wizard
            });
        }
    }
}