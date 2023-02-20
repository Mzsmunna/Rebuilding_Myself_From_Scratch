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
        public string ClipID { get; set; } = string.Empty;
        public List<string> MomentIDs { get; set; } = new List<string>();
        public BasicInfo BattingTeamInfo { get; set; } = new BasicInfo();
        public BasicInfo BowlingTeamInfo { get; set; } = new BasicInfo();
        public BasicInfo UmpireInfo { get; set; } = new BasicInfo();
        public BasicInfo LegUmpireInfo { get; set; } = new BasicInfo();
        public BasicInfo ThirdUmpireInfo { get; set; } = new BasicInfo();
        public BasicInfo RefreeInfo { get; set; } = new BasicInfo();
        public BasicInfo StrikerBatsmanInfo { get; set; } = new BasicInfo();
        public BasicInfo NonStrikerBatsmanInfo { get; set; } = new BasicInfo();
        public BasicInfo BowlerInfo { get; set; } = new BasicInfo();
        public BasicInfo FieldingSetupInfo { get; set; } = new BasicInfo();
        public BasicInfo FielderInfo { get; set; } = new BasicInfo();
        public BasicInfo SecondaryFielderInfo { get; set; } = new BasicInfo();
        public BasicInfo WicketKeeperInfo { get; set; } = new BasicInfo();
        public string BowlerAction { get; set; } = string.Empty; // pacer, spinner,
        public string BowlingStyle { get; set; } = string.Empty; // Leg, Off, Left Arm, Right Arm, Medium, etc
        public string BallType { get; set; } = string.Empty; // In Swing, Out Swing, Googly, Doosra, etc
        public string BallPitched { get; set; } = string.Empty; //(x, y) coordinate value
        public string BallLength { get; set; } = string.Empty; // good, full, short, yourker, half-holly, etc
        public double BallSpeed { get; set; } = 0;
        public string FielderPosition { get; set; } = string.Empty; //gully, silly, 1st-slip, 2nd-slip, etc
        public bool IsSubstituteFilder { get; set; }
        public bool IsOut { get; set; }
        public bool IsCaught { get; set; }
        public bool IsCaughtBehind { get; set; }
        public bool IsSloppyCatch { get; set; }
        public bool IsCombinedCaught { get; set; }
        public bool IsCatchDropped { get; set; }
        public bool IsRunOut { get; set; }
        public bool IsCombinedRunOut { get; set; }
        public bool IsMankading { get; set; }
        public bool IsRunOutMissed { get; set; }
        public bool IsMissFielding { get; set; }
        public bool IsOverThrow { get; set; }
        public bool IsExtraOrdinaryFielding { get; set; }
        public bool IsExtraOrdinaryCatch { get; set; }
        public bool IsBlowled { get; set; }
        public bool IsLBW { get; set; }
        public bool IsHitWicket { get; set; }
        public bool IsRetiredHurt { get; set; }
        public bool IsReviewed { get; set; }
        public bool IsReviewOverturned { get; set; }
        public string ReviewedByTeam { get; set; } = string.Empty; // batting team id / bowling team id
        public bool IsDecitionDoubleChecked { get; set; }
        public string SoftSignal { get; set; } = string.Empty;
        public bool IsStumped { get; set; }
        public bool IsDot { get; set; }
        public bool IsDefended { get; set; }
        public bool IsMissed { get; set; }
        public bool IsLeftAlone { get; set; }
        public bool IsExtra { get; set; }
        public bool IsByRun { get; set; }
        public bool IsLegByRun { get; set; }
        public bool IsWide { get; set; }
        public bool IsNoBall { get; set; }
        public string NoBallReason { get; set; } = string.Empty; // Height, Overstepping, 2+ Bouncers, fake fielding, fielding rules voilance etc
        public bool IsBackFoot { get; set; }
        public bool IsEdge { get; set; }
        public bool IsOne { get; set; }
        public bool IsTwo { get; set; }
        public bool IsThree { get; set; }
        public bool IsFour { get; set; }
        public bool IsSix { get; set; }
        public int SixDistance { get; set; } = 0;
        public int Run { get; set; } = 0;
        public int ExtraRun { get; set; } = 0;
        public int BonusRun { get; set; } = 0;
        public string BonusReason { get; set; } = string.Empty; // miss field, overthrow, overboundary, BTH
        public int HitDistance { get; set; } = 0;
        public int HitAngle { get; set; } = 0; // angle degree + hdista
        public string HittingZone { get; set; } = string.Empty; // straight, long-on, long-off, cover, 3rd man, etc
        public string ShotType { get; set; } = string.Empty; // straight-drive, cover-drive, square-drive, square-cut, pull, hook, sweep etc
        public double Batspeed { get; set; } = 0;
        public string CurrentOver { get; set; } = string.Empty; //12.1, 25.5, 49, etc
        public string OverID { get; set; } = string.Empty;
        public string CreatedOn { get; set; } = string.Empty;
    }
}
