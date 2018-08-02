namespace HRSaga
{
    public interface IPopulationService
    {
        CreatureModel GetCreatureById(string id);
        
        CreatureModel GetAnyCreatureByType(string type);

        void AddCreature(CreatureModel creatureModel);
    }
}