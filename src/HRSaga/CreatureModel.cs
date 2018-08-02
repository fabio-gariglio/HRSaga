namespace HRSaga
{
    public class CreatureModel
    {
        public string Id { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"{Type} ({Id})";
        }
    }
}