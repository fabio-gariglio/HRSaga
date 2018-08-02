using System.Collections.Generic;

namespace HRSaga.GameContext
{
    
    public class SquadMemberModel
    {
        public string Id { get; set; }
        public string Type { get; set; }
    }
    public class SquadModel
    {
        public string Id { get; set; }
        public bool Completed { get; set; }
        public List<SquadMemberModel> Members { get; } = new List<SquadMemberModel>();
    }
    
    public class CaptainModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public SquadModel Squad { get; set; }       
    }
}