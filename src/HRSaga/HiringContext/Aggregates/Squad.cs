using System;
using System.Collections.Generic;
using EventSourcing;
using HRSaga.HiringContext.DomainEvent;

namespace HRSaga.HiringContext.Aggregates
{
    public class Squad : AggregateBase
    {
        private readonly HashSet<string> _memberIds = new HashSet<string>();
        
        public Squad()
        {
        }
        
        public Squad(string captainId)
        {
            Apply(new SquadCreatedDomainEvent
            {
                SquadId = Guid.NewGuid().ToString(),
                CaptainId = captainId
            });
        }

        public void Hire(CreatureModel creatureModel)
        {
            if (_memberIds.Count == 5)
            {
                throw new InvalidOperationException($"You cannot hire more than five members.");
            }
            
            switch (creatureModel.Type)
            {
                case CreatureType.Wizard:
                    HireWizard(creatureModel.Id);
                    break;
                case CreatureType.Warrior:
                    HireWarrior(creatureModel.Id);
                    break;
                default:
                    throw new InvalidOperationException($"A creature of type '{creatureModel.Type}' cannot be hired.");
            }
        }

        private void HireWizard(string wizardId)
        {
            if (_memberIds.Contains(wizardId)) return;

            Apply(new WizardHiredDomainEvent
            {
                SquadId = Id,
                WizardId = wizardId
            });
            
            CheckSquadCompleted();
        }

        private void HireWarrior(string warriorId)
        {
            if (_memberIds.Contains(warriorId)) return;

            Apply(new WarriorHiredDomainEvent
            {
                SquadId = Id,
                WarriorId = warriorId
            });

            CheckSquadCompleted();
        }

        private void CheckSquadCompleted()
        {
            if (_memberIds.Count < 5) return;
            
            Apply(new SquadCompletedDomainEvent
            {
                SquadId = Id
            });
        }

        private void When(SquadCreatedDomainEvent @event)
        {
            Id = @event.SquadId;
        }
        
        private void When(WizardHiredDomainEvent @event)
        {
            _memberIds.Add(@event.WizardId);
        }
        
        private void When(WarriorHiredDomainEvent @event)
        {
            _memberIds.Add(@event.WarriorId);
        }
    }
}