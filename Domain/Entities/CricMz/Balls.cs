using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class Balls : IEntity
    {
        public string ID { get; set; } = string.Empty;
        public BasicInfo MatchInfo { get; set; } = new BasicInfo();
        public BasicInfo CommentaryInfo { get; set; } = new BasicInfo();
        public BasicInfo ClipInfo { get; set; } = new BasicInfo();
        //public List<string> MomentIDs { get; set; } = new List<string>();
        public BasicInfo BattingTeamInfo { get; set; } = new BasicInfo();
        public BasicInfo BowlingTeamInfo { get; set; } = new BasicInfo();
        public BasicInfo StampUmpireInfo { get; set; } = new BasicInfo();
        public BasicInfo LegUmpireInfo { get; set; } = new BasicInfo();
        public BasicInfo TvUmpireInfo { get; set; } = new BasicInfo();
        public BasicInfo MatchRefreeInfo { get; set; } = new BasicInfo();
        public BasicInfo StrikerBatsmanInfo { get; set; } = new BasicInfo();
        public BasicInfo NonStrikerBatsmanInfo { get; set; } = new BasicInfo();
        public BasicInfo BowlerInfo { get; set; } = new BasicInfo();
        public BasicInfo FieldingSetupInfo { get; set; } = new BasicInfo();
        public BasicInfo FielderInfo { get; set; } = new BasicInfo();
        public BasicInfo AssistFielderInfo { get; set; } = new BasicInfo();
        public BasicInfo WicketKeeperInfo { get; set; } = new BasicInfo();
        public string BowlingArm { get; set; } = string.Empty; // left, right,
        public string BowlingAction { get; set; } = string.Empty; // pacer, spinner,
        public string BowlingStyle { get; set; } = string.Empty; // Leg, Off, Left Arm, Right Arm, Medium, etc
        public string BallType { get; set; } = string.Empty; // In Swing, Out Swing, Googly, Doosra, etc
        public string BallPitched { get; set; } = string.Empty; //(x, y) coordinate value
        public string BallLength { get; set; } = string.Empty; // good, full, short, yourker, half-holly, etc
        public string FielderPosition { get; set; } = string.Empty; //gully, silly, 1st-slip, 2nd-slip, etc
        public bool IsSubstituteFilder { get; set; }
        public bool IsDot { get; set; }
        public bool IsDefended { get; set; }
        public bool IsMissed { get; set; }
        public bool IsLeftAlone { get; set; }
        public bool IsBackFoot { get; set; }
        public bool IsEdge { get; set; }
        public bool IsOne { get; set; }
        public bool IsTwo { get; set; }
        public bool IsThree { get; set; }
        public bool IsFour { get; set; }
        public bool IsSix { get; set; }
        public int HitDistance { get; set; } = 0;
        public int HitAngle { get; set; } = 0; // angle degree + hdista
        public string HittingZone { get; set; } = string.Empty; // 0-11
        public string HittingArea { get; set; } = string.Empty; // straight, long-on, long-off, cover, 3rd man, etc
        public string ShotSelection { get; set; } = string.Empty; // straight-drive, cover-drive, square-drive, square-cut, pull, hook, sweep etc
        public double Batspeed { get; set; } = 0;
        public double BallSpeed { get; set; } = 0;
        public int Run { get; set; } = 0;
        public int ExtraRun { get; set; } = 0;
        public int BonusRun { get; set; } = 0;
        public string BonusReason { get; set; } = string.Empty; // miss field, overthrow, overboundary, fake fielding, fielding rules voilance, etc
        public bool IsExtra { get; set; }
        public bool IsByRun { get; set; }
        public bool IsLegByRun { get; set; }
        public bool IsWide { get; set; }
        public string WideBallType { get; set; } = string.Empty; // leg, off
        public bool IsNoBall { get; set; }
        public string NoBallReason { get; set; } = string.Empty; // Height, Overstepping, 2+ Bouncers, fake fielding, fielding rules voilance, etc
        public bool IsOut { get; set; }
        public bool IsRetiredHurt { get; set; }
        public string OutType { get; set; } = string.Empty; // RunOut, Caught, CaughtBehind, Blowled, LBW, HitWicket, Stumped, Mankading
        public bool IsSloppyCatch { get; set; }
        public bool IsCombinedCatch { get; set; }
        public bool IsCatchDropped { get; set; }
        public bool IsCombinedRunOut { get; set; }
        public bool IsRunOutMissed { get; set; }
        public bool IsMissFielding { get; set; }
        public bool IsOverThrow { get; set; }
        public bool IsExtraOrdinaryFielding { get; set; }
        public bool IsExtraOrdinaryCatch { get; set; }
        public bool IsDecitionDoubleChecked { get; set; }
        public bool IsReviewed { get; set; }
        public bool IsReviewLost { get; set; }
        public bool IsReviewOverturned { get; set; }
        public string ReviewOverview { get; set; } = string.Empty; // EDGE, HITTING WICKET, UMPIRE-CALL, MISSING-WICKET, NO-EDGE
        public string ReviewedTeamID { get; set; } = string.Empty; // batting team id / bowling team id
        public string SoftSignal { get; set; } = string.Empty; // OUT / NOT OUT
        public double CurrentOver { get; set; } = 0; //12.1, 25.5, 49, etc
        public int BallNo { get; set; } = 0;
        public int Minutes { get; set; } = 0;
        //public string OverID { get; set; } = string.Empty;
        public Milestones Milestones { get; set; }
        public Achievements Achievements { get; set; }
        public string CreatedOn { get; set; } = string.Empty;
    }

    public class Milestones
    {
        public string StrikerBatsmanMilestone { get; set; } = string.Empty; // FIFTIES, HUNDREDS, DOUBLE-HUNDREDS, TRIPLE-HUNDREDS, 6SIXES, 6FOURS,
        public string NonStrikerBatsmanMilestone { get; set; } = string.Empty; // FIFTIES, HUNDREDS, DOUBLE-HUNDREDS, TRIPLE-HUNDREDS
        public string BowlerMilestone { get; set; } = string.Empty; // HAT-TRICK, FIFER
        public string FielderMilestone { get; set; } = string.Empty; // HAT-TRICK CATCHES, HAT-TRICK RUN-OUTS
        public string KeeperMilestone { get; set; } = string.Empty; // HAT-TRICK CATCHES, HAT-TRICK RUN-OUTS, HAT-TRICK STAMPINGS
    }

    public class Achievements
    {
        public string StrikerBatsmanAchievement { get; set; } = string.Empty; // 500RUNS, 1000RUNS, 2000RUNS, 5000RUNS & 100WICKETS, ETC
        public string NonStrikerBatsmanAchievement { get; set; } = string.Empty; // 500RUNS, 1000RUNS, 2000RUNS, 5000RUNS & 100WICKETS, ETC
        public string BowlerAchievement { get; set; } = string.Empty; // 100WICKETS, 200WICKETS, 300WICKETS, 100WICKETS & 1000RUNS, ETC
        public string FielderAchievement { get; set; } = string.Empty; // 100 CATCHES, 50 RUN-OUTS
        public string KeeperAchievement { get; set; } = string.Empty; // 100 CATCHES, 50 RUN-OUTS, 50 STAMPINGS
    }
}
