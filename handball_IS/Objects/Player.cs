namespace handball_IS.Objects
{
    public class Player
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int GoalCount { get; set; }
        public int SevenMeterGoalCount { get; set; }
        public int SevenMeterMissCount { get; set; }
        public int TwoMinPenaltyCount { get; set; }
        public int RedCardCount { get; set; }
        public int YellowCardCount { get; set; }

        // Foreign keys
        public int? TeamId { get; set; }
        public Team? Team { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
