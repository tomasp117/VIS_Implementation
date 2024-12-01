namespace handball_IS.Objects
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public List<Actors.sub.Coach> Coaches { get; set; }
        public List<Match> matches { get; set; }
    }
}
