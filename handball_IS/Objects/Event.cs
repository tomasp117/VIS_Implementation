namespace handball_IS.Objects
{
    public class Event
    {
        public int Id { get; set; }
        public char Type { get; set; }
        public Team Team { get; set; }
        public string Time { get; set; }
        public int AuthorId { get; set; }

        // Foreign keys
        public int MatchId { get; set; }
    }
}
