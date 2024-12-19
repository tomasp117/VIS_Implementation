using handball_IS.Objects.Actors.sub;

namespace handball_IS.Objects
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation properties
        public List<Player> Players { get; set; } = new List<Player>();
        public List<Coach> Coaches { get; set; } = new List<Coach>();

        public Group? Group { get; set; } = null!;


        // Foreign keys
        public int ClubId { get; set; }
        public Club Club { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int TournamentInstanceId { get; set; }
        public TournamentInstance TournamentInstance { get; set; } = null!;

        public List<Match> HomeMatches { get; set; } = new List<Match>();
        public List<Match> AwayMatches { get; set; } = new List<Match>();


    }
}
