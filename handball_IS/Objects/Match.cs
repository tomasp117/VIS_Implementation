using handball_IS.Objects.Actors.sub;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.Xml;

namespace handball_IS.Objects
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int TimePlayed { get; set; }
        public string Playground { get; set; } = string.Empty;
        public string Score { get; set; } = "0:0";
        public string State { get; set; } = "msNone"; 

        // Navigation properties
        public List<Event> Events { get; set; } = new List<Event>();
        public Category? Category { get; set; } = null!;
        
        // Foreign keys
        // Teams
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; } = null!;

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; } = null!;

        // Referees
        public int MainRefereeId { get; set; }
        public Referee MainReferee { get; set; } = null!;

        public int? AssistantRefereeId { get; set; } 
        public Referee? AssistantReferee { get; set; } = null!;

        // Group
        public int GroupId { get; set; }
        public Group Group { get; set; } = null!;

    }
}
