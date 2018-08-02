using System;
using EventSourcing;
using HRSaga.GameContext.DomainEvents;
using HRSaga.HiringContext.DomainEvent;

namespace HRSaga.GameContext.EventHandlers
{
    public class CaptainModelProjection :
        IEventHandler<CaptainCreatedDomainEvent>,
        IEventHandler<SquadCreatedDomainEvent>,
        IEventHandler<WarriorHiredDomainEvent>,
        IEventHandler<WizardHiredDomainEvent>,
        IEventHandler<SquadCompletedDomainEvent>
    {
        private readonly ICaptainService _captainService;

        public CaptainModelProjection(ICaptainService captainService)
        {
            _captainService = captainService;
        }

        public void Handle(CaptainCreatedDomainEvent @event)
        {
            CreateOrUpdateCaptain(@event.CaptainId, captain => { captain.Name = @event.CaptainName; });
        }

        public void Handle(SquadCreatedDomainEvent @event)
        {
            CreateOrUpdateCaptain(@event.CaptainId,
                captain => { captain.Squad = new SquadModel {Id = @event.SquadId}; });
        }

        public void Handle(WarriorHiredDomainEvent @event)
        {
            UpdateCaptain(captain => captain.Squad.Members.Add(new SquadMemberModel
            {
                Id = @event.WarriorId,
                Type = CreatureType.Warrior
            }));
        }

        public void Handle(WizardHiredDomainEvent @event)
        {
            UpdateCaptain(captain => captain.Squad.Members.Add(new SquadMemberModel
            {
                Id = @event.WizardId,
                Type = CreatureType.Wizard
            }));
        }
        
        public void Handle(SquadCompletedDomainEvent @event)
        {
            UpdateCaptain(captain => captain.Squad.Completed = true);
        }

        private void CreateOrUpdateCaptain(string captainId, Action<CaptainModel> updateAction)
        {
            var captain = _captainService.Get() ?? new CaptainModel {Id = captainId};

            updateAction(captain);

            _captainService.Save(captain);
        }

        private void UpdateCaptain(Action<CaptainModel> updateAction)
        {
            var captain = _captainService.Get();

            updateAction(captain);

            _captainService.Save(captain);
        }


    }
}