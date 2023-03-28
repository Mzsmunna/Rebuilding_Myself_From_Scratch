using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class ScoreBoard : IEntity
    {
        public Score HomeTeam { get; set; } = new Score();
        public Score AwayTeam { get; set; } = new Score();
        public BasicInfo? ManOfMatch { get; set; } = null;
        public BasicInfo? ManOfSeries { get; set; } = null;
        public BasicInfo? ManOfTournament { get; set; } = null;
        public List<Award>? OtherAwards { get; set; } = null;
        public string MatchResult { get; set; } = string.Empty;
        public string MatchWinsBy { get; set; } = string.Empty; // Runs / Wickets
        public bool IsDLSApplied { get; set; }
    }

    public class Award
    {
        public string AwardID { get; set; } = string.Empty;
        public string AwardName { get; set; } = string.Empty;
        public string PoweredBy { get; set; } = string.Empty;
        public string PlayerID { get; set; } = string.Empty;
    }
}
