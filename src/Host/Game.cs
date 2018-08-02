using System;
using EventSourcing;
using HRSaga;
using HRSaga.GameContext.Commands;
using HRSaga.HiringContext.Commands;

namespace Host
{
    public class Game
    {
        private readonly Random _random;
        private readonly ICommandSender _commandSender;
        private readonly IPopulationService _populationService;
        private readonly ICaptainService _captainService;

        public Game(ICommandSender commandSender, IPopulationService populationService, ICaptainService captainService)
        {
            _random = new Random();
            _commandSender = commandSender;
            _populationService = populationService;
            _captainService = captainService;
        }

        public void Start()
        {
            _commandSender.Send(new CreateWorldCommand
            {
                NumberOfWarriors = _random.Next(5, 10),
                NumberOfWizards = _random.Next(5, 10)
            });

            var captain = _captainService.Get();

            do
            {
                var creatureType = _random.Next(0, 100) % 2 == 0
                    ? CreatureType.Warrior
                    : CreatureType.Wizard;

                var creature = _populationService.GetAnyCreatureByType(creatureType);

                _commandSender.Send(new HireMemberCommand
                {
                    SquadId = captain.Squad.Id,
                    MemberId = creature.Id
                });
            } while (!_captainService.Get().Squad.Completed);
        }
    }
}