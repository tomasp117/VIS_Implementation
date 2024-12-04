namespace handball_IS.Objects
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation properties
        public List<TournamentInstance> Editions { get; set; } = new List<TournamentInstance>();
    }
}
