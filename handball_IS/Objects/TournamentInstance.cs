namespace handball_IS.Objects
{
    public class TournamentInstance
    {
        public int Id { get; set; }
        public int EditionNumber { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public List<Team> Teams { get; set; }
        public List<Category> Categories { get; set; }

        public int TournamentId { get; set; }

        public Tournament Tournament { get; set; }
    }
}
