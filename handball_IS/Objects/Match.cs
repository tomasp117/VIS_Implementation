using Microsoft.Extensions.Logging;
using System.Security.Cryptography.Xml;

namespace handball_IS.Objects
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int TimePlayed { get; set; }
        public string Playground { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public string Score { get; set; }
        public string State { get; set; }
        public List<Event> Events { get; set; }
        public List<Actors.sub.Referee> Referees { get; set; }
    }
}
