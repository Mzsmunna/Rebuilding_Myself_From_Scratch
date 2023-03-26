using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class Squad
    {
        //public BasicInfo TeamInfo { get; set; } = new BasicInfo();
        public ScoreCard ScoreCard { get; set; } = new ScoreCard();
        public List<Performers> Players { get; set; } = new List<Performers>();
    }

    public class Performers
    {
        public BasicInfo PlayerInfo { get; set; } = new BasicInfo();
        public string Role { get; set; } = string.Empty;
        public bool IsPlaying { get; set; }
        public bool IsCaptain { get; set; }
        public bool IsKeeper { get; set; }
        public bool IsSubstitute { get; set; }
        public bool IsInjured { get; set; }
        public BattingPerformance BattingPerformance { get; set; }
        public BowlingPerformance BowlingPerformance { get; set; }
        public FieldingPerformance FieldingPerformance { get; set; }
    }

    public class BattingPerformance
    {
        public int BattingOrder { get; set; } = 0;
        public string BattingHand { get; set; } = string.Empty;
        public int Runs { get; set; } = 0;
        public int Balls { get; set; } = 0;
        public int Dots { get; set; } = 0;
        public int Ones { get; set; } = 0;
        public int Twos { get; set; } = 0;
        public int Threes { get; set; } = 0;
        public int Fours { get; set; } = 0;
        public int Sixes { get; set; } = 0;
        public int Lucky { get; set; } = 0;
        public int Edges { get; set; } = 0;
        public double StrikeRate { get; set; } = 0;
        public int Minutes { get; set; } = 0;
        public bool IsOut { get; set; } = false;
        public bool IsRetiredHurt { get; set; } = false;
        public string OutType { get; set; } = string.Empty; //RunOut, Caught, Bold, LBW, HitWicket, Stumped
        public string BowlerID { get; set; } = string.Empty;
        public string FielderID { get; set; } = string.Empty;
        public string AssistFielderID { get; set; } = string.Empty;
        public string WicketKeeperID { get; set; } = string.Empty;
        public DateTime? PlayerIn { get; set; }
        public DateTime? PlayerOut { get; set; }
    }

    public class BowlingPerformance
    {
        public string BowlingArm { get; set; } = string.Empty; // left, right,
        public string BowlingAction { get; set; } = string.Empty; // pacer, spinner,
        public int Wickets { get; set; } = 0;
        public int Bowled { get; set; } = 0;
        public int LBW { get; set; } = 0;
        public int Caughts { get; set; } = 0;
        public int HitWickets { get; set; } = 0;
        public int RetiredHurts { get; set; } = 0;
        public int Runs { get; set; } = 0;
        public int Balls { get; set; } = 0;
        public int Maidens { get; set; } = 0;
        public int Dots { get; set; } = 0;
        public int Ones { get; set; } = 0;
        public int Twos { get; set; } = 0;
        public int Threes { get; set; } = 0;
        public int Fours { get; set; } = 0;
        public int Sixes { get; set; } = 0;
        public double EconomyRate { get; set; } = 0;
        public int Unlucky { get; set; } = 0;
    }

    public class FieldingPerformance
    {
        public string FieldingPositions { get; set; } = string.Empty; // ","
        public string FieldingZones { get; set; } = string.Empty; // ","
        public string FieldingHand { get; set; } = string.Empty; // ","
        public int RunOuts { get; set; } = 0;
        public int AssistRunOuts { get; set; } = 0;
        public int MissedRunOuts { get; set; } = 0;
        public int Mankadings { get; set; } = 0;
        public int Catches { get; set; } = 0;
        public int AssistCatches { get; set; } = 0;
        public int DroppedCatches { get; set; } = 0;
        public int Stumpings { get; set; } = 0;
    }
}
