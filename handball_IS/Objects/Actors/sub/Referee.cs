namespace handball_IS.Objects.Actors.sub
{
    public class Referee : super.Person
    {
        public char License { get; set; }


        // Foreign keys
        public List<Match> MainRefereeMatches { get; set; } = new List<Match>();
        public List<Match> AssistantRefereeMatches { get; set; } = new List<Match>();
    }
}
