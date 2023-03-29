using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class Score
    {
        public int Target { get; set; } = 0;
        public int Runs { get; set; } = 0;
        public int Extras { get; set; } = 0;
        public int Balls { get; set; } = 0;
        public int RemainingBalls { get; set; } = 0;
        public int Wickets { get; set; } = 0;
        public int Over { get; set; } = 0;
        public int OverBallNo { get; set; } = 0; // Max =  6 / 5
        public double CurrentRunRate { get; set; } = 0;
        public double RequireRunRate { get; set; } = 0;
        public int WideRuns { get; set; } = 0;
        public int ByeRuns { get; set; } = 0;
        public int LegByeRuns { get; set; } = 0;
        public int BonusRuns { get; set; } = 0;
        public int Dots { get; set; } = 0;
        public int Ones { get; set; } = 0;
        public int Twos { get; set; } = 0;
        public int Threes { get; set; } = 0;
        public int Fours { get; set; } = 0;
        public int Fives { get; set; } = 0;
        public int Sixes { get; set; } = 0;
        public int Sevens { get; set; } = 0;
        public int NoBalls { get; set; } = 0;
        public int WideBalls { get; set; } = 0;
        public List<Performance> Performances { get; set; } = new List<Performance>(); // Max Length 11
        public List<Partnership> Partnerships { get; set; } = new List<Partnership>();
    }

    public class Squard
    {
        public BasicInfo TeamInfo { get; set; } = new BasicInfo();
        public List<Performer> Players { get; set; } = new List<Performer>();
        public Score FirstInnings { get; set; } = new Score();
        public Score? SecondInnings { get; set; } = null; // Only if Match Format is TEST
    }

    public class Scorer
    {
        public Identity PlayerIdentity { get; set; } = new Identity();
        public int RunScored { get; set; } = 0;
        public int BallPlayed { get; set; } = 0;
        public int RunGiven { get; set; } = 0;
        public int BallDelivered { get; set; } = 0;
        public int WicketTaken { get; set; } = 0;
        public int CatchTaken { get; set; } = 0;
        public int RunOuts { get; set; } = 0;
        public int Stumped { get; set; } = 0;
    }

    public class Partnership
    {
        public string TeamID { get; set; } = string.Empty;
        public string FirstPlayerID { get; set; } = string.Empty;
        public int FirstPlayerContribution { get; set; } = 0;
        public string SecondPlayerID { get; set; } = string.Empty;
        public int SecondPlayerContribution { get; set; } = 0;
        public int TotalContributions { get; set; } = 0;
        public bool IsUnbroken { get; set; } = false;
        public int? FallOfWickets { get; set; } = null;
        public int WicketsNo { get; set; } = 1;
        public string OutType { get; set; } = string.Empty; // RunOut, Caught, CaughtBehind, Caught&Bowled, Blowled, LBW, HitWicket, Stumped, Mankading, RetiredHurt, RetiredOut, TimedOut, HitBallTwice, ObstructingField, Absent
        public string BowlerID { get; set; } = string.Empty;
        public string FielderID { get; set; } = string.Empty;
        public string AssistFielderID { get; set; } = string.Empty;
        public string WicketKeeperID { get; set; } = string.Empty;
    }

    public class Performer
    {
        public BasicInfo PlayerInfo { get; set; } = new BasicInfo();
        public string Role { get; set; } = string.Empty;
        public bool IsPlaying { get; set; }
        public bool IsCaptain { get; set; }
        public bool IsViceCaptain { get; set; }
        public bool IsKeeper { get; set; }
        public bool IsSubstitute { get; set; }
        public bool IsInjured { get; set; }
    }

    public class Performance
    {
        public string PlayerID { get; set; } = string.Empty;
        public BattingPerformance? BattingPerformance { get; set; } = null;
        public BowlingPerformance? BowlingPerformance { get; set; } = null;
        public FieldingPerformance? FieldingPerformance { get; set; } = null;
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
        public int Fives { get; set; } = 0;
        public int Sixes { get; set; } = 0;
        public int Sevens { get; set; } = 0;
        public int Lucky { get; set; } = 0;
        public int Edges { get; set; } = 0;
        public double StrikeRate { get; set; } = 0;
        public int Minutes { get; set; } = 0;
        public bool IsOut { get; set; } = false;
        public bool IsRetiredHurt { get; set; } = false;
        public string OutType { get; set; } = string.Empty; // RunOut, Caught, CaughtBehind, Caught&Bowled, Blowled, LBW, HitWicket, Stumped, Mankading, RetiredHurt, RetiredOut, TimedOut, HitBallTwice, ObstructingField, Absent
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
        public int Extras { get; set; } = 0;
        public int Balls { get; set; } = 0;
        public int NoBalls { get; set; } = 0;
        public int WideBalls { get; set; } = 0;
        public int Maidens { get; set; } = 0;
        public int Dots { get; set; } = 0;
        public int Ones { get; set; } = 0;
        public int Twos { get; set; } = 0;
        public int Threes { get; set; } = 0;
        public int Fours { get; set; } = 0;
        public int Fives { get; set; } = 0;
        public int Sixes { get; set; } = 0;
        public int Sevens { get; set; } = 0;
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

    public class Award
    {
        public string AwardID { get; set; } = string.Empty;
        public string AwardName { get; set; } = string.Empty;
        public string PoweredBy { get; set; } = string.Empty;
        public string PlayerID { get; set; } = string.Empty;
    }
}
