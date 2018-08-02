using System;
using System.Collections.Generic;
using System.Linq;
using HRSaga;

namespace Host
{
    public class InMemoryPopulationService : IPopulationService
    {
        private readonly Random _random = new Random();
        private readonly IDictionary<string, CreatureModel> _population = new Dictionary<string, CreatureModel>();
        
        public CreatureModel GetCreatureById(string id)
        {
            return _population.TryGetValue(id, out var creature)
                ? creature
                : null;
        }

        public CreatureModel GetAnyCreatureByType(string type)
        {
            var creatures = _population.Values.Where(c => c.Type == type).ToArray();

            return creatures[_random.Next(0, creatures.Length)];
        }

        public void AddCreature(CreatureModel creatureModel)
        {
            _population[creatureModel.Id] = creatureModel;
        }
    }
}