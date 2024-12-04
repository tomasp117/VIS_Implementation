namespace handball_IS.Objects
{
    public class TournamentInstance
    {
        public int Id { get; set; }
        public int EditionNumber { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        // Navigation properties
        public List<Team> Teams { get; set; } = new List<Team>();
        public List<Category> Categories { get; set; } = new List<Category>();


        // Foreign keys
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; } = null!;
    }
}
