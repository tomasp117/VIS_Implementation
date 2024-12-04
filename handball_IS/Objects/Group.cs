namespace handball_IS.Objects
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation properties
        public List<Team>? Teams { get; set; } = new List<Team>();
        public List<Match> Matches { get; set; } = new List<Match>();

        // Foreign keys
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
