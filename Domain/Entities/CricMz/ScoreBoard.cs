using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class ScoreBoard : IEntity
    {
        public Score HomeTeamScore { get; set; } = new Score();
        public Score AwayTeamScore { get; set; } = new Score();
        public BasicInfo ManOfMatch { get; set; } = new BasicInfo();
        public BasicInfo ManOfSeries { get; set; } = new BasicInfo();
        public List<Award> OtherRewards { get; set; }
        public string MatchResult { get; set; } = string.Empty;
        public string MatchWinsBy { get; set; } = string.Empty; // Runs / Wickets
        public bool IsDRSApplied { get; set; }
    }

    public class Score : IEntity
    {
        public BasicInfo TeamInfo { get; set; } = new BasicInfo();
        public int Runs { get; set; } = 0;
        public int Balls { get; set; } = 0;
        public int Overs { get; set; } = 0;
        public int Extras { get; set; } = 0;
        public int Wickets { get; set; } = 0;
        public int Target { get; set; } = 0;
        public bool IsWinner { get; set; } = false;
    }

    public class Award
    {
        public BasicInfo AwardInfo { get; set; } = new BasicInfo();
        public BasicInfo PlayerInfo { get; set; } = new BasicInfo();
    }
}
