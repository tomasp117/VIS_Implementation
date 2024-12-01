namespace handball_IS.Objects
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TournamentInstance> Editions { get; set; }
    }
}
