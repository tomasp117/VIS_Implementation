namespace handball_IS.Objects
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool VoitingOpen { get; set; }
        public List<Match> Matches { get; set; }
        public List<Group> Groups { get; set; }
        public List<Vote> Voting { get; set; }
        public List<PlayerStats> Stats { get; set; }

        public int TournamentInstanceId { get; set; }

        public TournamentInstance TournamentInstance { get; set; }
    }
}
