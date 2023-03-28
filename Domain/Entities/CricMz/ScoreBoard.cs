using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class ScoreBoard : IEntity
    {
        
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
