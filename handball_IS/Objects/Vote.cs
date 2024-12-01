namespace handball_IS.Objects
{
    public class Vote
    {
        public int Id { get; set; }
        public Actors.sub.Coach voter { get; set; }
        public Player Player { get; set; }
        public char type { get; set; }
    }
}
