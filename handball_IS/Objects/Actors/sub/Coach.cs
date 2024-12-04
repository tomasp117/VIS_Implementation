namespace handball_IS.Objects.Actors.sub
{
    public class Coach : super.Person
    {
        public Player? playerVote { get; set; } = null!;
        public Player? goalkeeperVote { get; set; } = null!;
        public char License { get; set; }

        // Foreign keys
        public int TeamId { get; set; }
        public Team Team { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
