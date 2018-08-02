using EventSourcing;
using HRSaga.HiringContext.Aggregates;
using HRSaga.HiringContext.Commands;

namespace HRSaga.HiringContext.CommandHandlers
{
    public class HireMemberCommandHandler : ICommandHandler<HireMemberCommand>
    {
        private readonly IAggregateRepository<Squad> _squadRepository;
        private readonly IPopulationService _populationService;

        public HireMemberCommandHandler(IAggregateRepository<Squad> squadRepository, IPopulationService populationService)
        {
            _squadRepository = squadRepository;
            _populationService = populationService;
        }
        
        public void Handle(HireMemberCommand command)
        {
            var squad = _squadRepository.GetById(command.SquadId);
            var creature = _populationService.GetCreatureById(command.MemberId);

            squad.Hire(creature);
            
            _squadRepository.Save(squad);
        }
    }
}