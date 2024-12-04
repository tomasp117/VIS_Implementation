namespace handball_IS.Objects
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Navigation properties
        public List<Team> Teams { get; set; } = new List<Team>();

    }
}
