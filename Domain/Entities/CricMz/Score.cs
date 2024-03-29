﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class Score
    {
        public DateTime? InningsStartedAt { get; set; } = null;
        public bool IsBattingFirst { get; set; } = true;
        public string CurrentOver { get; set; } = string.Empty; // "0,0,1,0NB,4,0,WB => WL|WS|WC|WCB|WC&B|WRNO|WRH|WRHO|WT|WHW|WHB2|WM|WOF|WA"
        public int Dots { get; set; } = 0;
        public int Ones { get; set; } = 0;
        public int Twos { get; set; } = 0;
        public int Threes { get; set; } = 0;
        public int Fours { get; set; } = 0;
        public int Fives { get; set; } = 0;
        public int Sixes { get; set; } = 0;
        public int Sevens { get; set; } = 0;
        public int Eights { get; set; } = 0;
        public int Runs { get; set; } = 0;
        public int Extras { get; set; } = 0;
        public int Bonus { get; set; } = 0;
        public int Wides { get; set; } = 0;
        public int Byes { get; set; } = 0;
        public int LegByes { get; set; } = 0;
        public int Wickets { get; set; } = 0;
        public int OverNo { get; set; }
        public int BallNo { get; set; } // max == BallPerOver
        public int Balls { get; set; } = 0;
        public int NoBalls { get; set; } = 0;
        public int WideBalls { get; set; } = 0;
        public int RemainingBalls { get; set; } = 0;
        public int MaxBalls { get; set; } = 0; // 50 over * 6 balls per over = 300 total balls in ODI, 20 * 6 = 120 in T20, 10 * 6 = 60 in T10, etc
        public int ReducedMaxBalls { get; set; } = 0; // 31 over * 6 balls per over = 186 total balls etc
        public int PartnershipOf { get; set; } = 0;
        public int PartnershipFrom { get; set; } = 0;
        public double CurrentRunRate { get; set; } = 0;
        public double RequireRunRate { get; set; } = 0;
        public Scorer? Striker { get; set; } = null;
        public Scorer? NonStriker { get; set; } = null;
        public Scorer? Bowler { get; set; } = null;
        //public Scorer? HighestScorer { get; set; } = null;
        //public Scorer? HighestWicketTaker { get; set; } = null;
        public DateTime? InningsEndedAt { get; set; } = null;
    }

    public class ScoreBoard
    {
        public BasicInfo TeamInfo { get; set; } = new BasicInfo();
        public Score FirstInnings { get; set; } = new Score();
        public Score? SecondInnings { get; set; } = null; // Only if Match Format is TEST
    }

    public class ScoreCard
    {
        public List<Over> Overs { get; set; } = new List<Over>();
        public List<Performance> Performances { get; set; } = new List<Performance>(); // Max length is generally 11
        public List<Partnership>? Partnerships { get; set; } = new List<Partnership>(); // can be null when UnconventionalRules.IsSoloMatch == true && UnconventionalRules.AllowDualBatting == false
        public List<Session>? Sessions { get; set; } = null; // Only if Match Format is TEST
    }

    public class Squard
    {
        public string TeamID { get; set; } = string.Empty;
        public List<Performer> Cricketers { get; set; } = new List<Performer>();
        public ScoreCard FirstInnings { get; set; } = new ScoreCard();
        public ScoreCard? SecondInnings { get; set; } = null; // Only if Match Format is TEST
    }

    public class Scorer
    {
        public BasicInfo CricketerInfo { get; set; } = new BasicInfo();
        public int RunScored { get; set; } = 0;
        public int FourScored { get; set; } = 0;
        public int SixScored { get; set; } = 0;
        public int BallPlayed { get; set; } = 0;
        public double Strike { get; set; } = 0;
        public bool IsOut { get; set; } = false;
        public int RunGiven { get; set; } = 0;
        public int FourGiven { get; set; } = 0;
        public int SixGiven { get; set; } = 0;
        public int WicketTaken { get; set; } = 0;
        public int BallDelivered { get; set; } = 0;
        public double Economy { get; set; } = 0;
        public int CatchTaken { get; set; } = 0;
        public int RunOuts { get; set; } = 0;
        public int Stumped { get; set; } = 0;
    }

    public class Partnership
    {
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

    public class Session
    {
        public int DayNo { get; set; } = 1;
        public int SessionNo { get; set; } = 1;
        public int FromOver { get; set; } = 1;
        public int ToOver { get; set; } = 10;
        public int Runs { get; set; } = 0;
        public int Balls { get; set; } = 0;
        public int RemainingBalls { get; set; } = 0;
        public int Wickets { get; set; } = 0;
    }

    public class Performer
    {
        public BasicInfo PlayerInfo { get; set; } = new BasicInfo();
        public string Role { get; set; } = string.Empty;
        public bool IsPlaying { get; set; }
        public bool IsCaptain { get; set; }
        public bool IsViceCaptain { get; set; }
        public bool IsKeeper { get; set; }
        public bool IsInjured { get; set; }
        public string SubstituteID { get; set; } = string.Empty;
        public string ReplacementID { get; set; } = string.Empty;
    }

    public class Over
    {
        public int OverNo { get; set; }
        public List<Bowl>? Balls { get; set; } = new List<Bowl>(); // minLength == BallPerOver -> 6  || public List<string> BallIds { get; set; } = new List<string>();
        public string Overview { get; set; } = string.Empty; // "0,1NB,1WD,4,1,3NB,6,2,WB / WL / WS / WC / WCB / WC&B / WRNO / WRH / WRHO / WT / WHW / WHB2 / WM / WOF / WA"; minLength == BallPerOver
    }

    public class Bowl
    {
        public int BallNo { get; set; } // max == BallPerOver
        public string Result { get; set; } = string.Empty; // 0 / 1NB / 2WD / 4 / 1 / 3NB / 6 / 2LB / 2 / WB / WL / WS / WC / WCB / WC&B / WRNO / WRH / WRHO / WT / WHW / WHB2 / WM / WOF / WA
        public string Comment { get; set; } = string.Empty;
        public string StrikerBatsmanID { get; set; } = string.Empty;
        public string NonStrikerBatsmanID { get; set; } = string.Empty;
        public string BowlerID { get; set; } = string.Empty;
        public string WicketKeeperID { get; set; } = string.Empty;
        public string FilderID { get; set; } = string.Empty;
        public string AssistFilderID { get; set; } = string.Empty;
        public string StampUmpireID { get; set; } = string.Empty;
        public string LegUmpireID { get; set; } = string.Empty;
        public string TvUmpireID { get; set; } = string.Empty;
        public string MatchRefreeID { get; set; } = string.Empty;
        public string FieldingSetupID { get; set; } = string.Empty;
        public string FielderID { get; set; } = string.Empty;
        public string AssistFielderID { get; set; } = string.Empty;
    }

    public class Performance
    {
        public string CricketerID { get; set; } = string.Empty;
        public bool InCharge { get; set; } = false;
        public bool IsBatted { get; set; } = false;
        public bool IsBowled { get; set; } = false;
        public bool IsFielded { get; set; } = true;
        public BattingPerformance? BattingPerformance { get; set; } = null;
        public BowlingPerformance? BowlingPerformance { get; set; } = null;
        public FieldingPerformance? FieldingPerformance { get; set; } = null;
    }

    public class BattingPerformance
    {
        public int BattingOrder { get; set; } = 0;
        public string BattingHand { get; set; } = string.Empty;
        public string BattingLines { get; set; } = string.Empty; // "x,x,x,0,0,1|4,0,4,2,0,1|1,x,x,x,x,6|0,0,3,x,x,x|0,2,0,WB / WL / WS / WC / WCB / WC&B / WRNO / WRH / WRHO / WT / WHW / WHB2 / WM / WOF / WA"
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
        public int Lucks { get; set; } = 0;
        public int Edges { get; set; } = 0;
        public int FrontFoots { get; set; } = 0;
        public int BackFoots { get; set; } = 0;
        public int StepOuts { get; set; } = 0;
        public int Lofts { get; set; } = 0;
        public double StrikeRate { get; set; } = 0;
        public int Minutes { get; set; } = 0;
        public bool IsOut { get; set; } = false;
        public bool IsAtNonStrike { get; set; } = false;
        public bool IsRetiredHurt { get; set; } = false;
        public string OutType { get; set; } = string.Empty; // Blowled, LBW, Stumped, Caught, CaughtBehind, Caught&Bowled, RunOut, HitWicket, Mankading, RetiredHurt, RetiredOut, TimedOut, HitBallTwice, ObstructingField, Absent
        public string BowlerID { get; set; } = string.Empty;
        public string FielderID { get; set; } = string.Empty;
        public string AssistFielderID { get; set; } = string.Empty;
        public string WicketKeeperID { get; set; } = string.Empty;
        public DateTime? PlayerIn { get; set; } = null;
        public DateTime? PlayerOut { get; set; } = null;
    }

    public class BowlingPerformance
    {
        public string BowlingArm { get; set; } = string.Empty; // left, right,
        public string BowlingAction { get; set; } = string.Empty; // pacer, spinner,                                                      
        public string BowlingLines { get; set; } = string.Empty; // "WB,0,1,4,0,0|2,0,0,6,0,0|3,0,0,WC,0,WS|WL,0,0,0,0,NB,WD,6"
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
        public string FieldingLines { get; set; } = string.Empty; // "x,x,1,4,0,WC|x,x,x,x,x,1|FNC,6,x,0,0,x|x,x,x,FA,WC&B,0|3,FCM,FROM,FCD,x,x"
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
        public string CricketerID { get; set; } = string.Empty;
    }
}
