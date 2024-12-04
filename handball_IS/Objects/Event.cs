namespace handball_IS.Objects
{
    public class Event
    {
        public int Id { get; set; }
        public char Type { get; set; }
        public string Team { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public int AuthorId { get; set; }

        // Foreign keys
        public int MatchId { get; set; }
        public Match Match { get; set; } = new Match();

    }
}
