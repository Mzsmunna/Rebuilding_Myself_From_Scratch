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
        public Commentating Commentary { get; set; } = new Commentating();
        public BasicInfo? ClipInfo { get; set; } = null;
        public WeatherForecast? WeatherForecast { get; set; } = null;
        //public List<string> MomentIDs { get; set; } = new List<string>();
        public Umpiring StampUmpire { get; set; } = new Umpiring();
        public Umpiring LegUmpire { get; set; } = new Umpiring();
        public Umpiring TvUmpire { get; set; } = new Umpiring();
        public Umpiring MatchRefree { get; set; } = new Umpiring();
        public Batting StrikerBatsman { get; set; } = new Batting();
        public Batting NonStrikerBatsman { get; set; } = new Batting();
        public Bowling Bowler { get; set; } = new Bowling();
        public BasicInfo FieldingSetupInfo { get; set; } = new BasicInfo();
        public Fielding Fielder { get; set; } = new Fielding();
        public Fielding AssistFielder { get; set; } = new Fielding();
        public Fielding WicketKeeper { get; set; } = new Fielding();
        public int Innings { get; set; } = 1; // TEST_MAX => 4, REST_MAX => 2
        public int Runs { get; set; } = 0;
        public string RunType { get; set; } = string.Empty; // dot, single, double, triple, boundary / four, over-boundary / six
        public bool IsOut { get; set; }
        public string OutType { get; set; } = string.Empty; // RunOut, Caught, CaughtBehind, Caught&Bowled, Blowled, LBW, HitWicket, Stumped, Mankading, RetiredHurt, RetiredOut, TimedOut, HitBallTwice, ObstructingField, Absent
        public string MatchType { get; set; } = string.Empty; // street, gully, rooftop, indoor, book, paper, local, area, national, international, league, franchise, friendly, charity
        public string MatchFormat { get; set; } = string.Empty; // Limited, ODI, ODI_40, TEST, TEST_4D, TEST_3D, T20I, T20, T10, SAS => Six_A_Site
        public string MatchBallType { get; set; } = string.Empty; // pingpong, sponge, plastic, rubber, tennis, tape_tennis, synthetic, hockey, cork, red_leather, white_leather, pink_leather, other
        public string MatchPitchType { get; set; } = string.Empty; // rough, cement, turf, astroturf, matting, green, dry, dusty, flat_track, wet, dead
        public int Extras { get; set; } = 0;
        public string ExtraReason { get; set; } = string.Empty; // bye, leg_bye, wide, noball
        public string ExtraSpecificReason { get; set; } = string.Empty; // bye, leg_bye, wide-outside_leg, wide-outside-off, wide-height, noball-height, noball-overstepping, noball-max_bouncers, noball-fake_fielding, noball-fielding_rules_voilance
        public int BonusRuns { get; set; } = 0;
        public string BonusReason { get; set; } = string.Empty; // miss field, overthrow, overboundary, fake fielding, fielding rules voilance, hitting helmet on field etc
        public double Over { get; set; } = 0; //12, 25, 49, etc
        public int OverBallNo { get; set; } = 0; // Max =  6 / 5
        public int TotalOver { get; set; } = 0; // 10, 20, 50, 90, etc
        public int ReducedOverTo { get; set; } = 0; // 8, 18, 27, 35, etc
        public string BallOverview { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }
        public string ModificationReason { get; set; } = string.Empty;
    }

    public class Batting
    {
        public BasicInfo BatsmanInfo { get; set; } = new BasicInfo();
        public BasicInfo TeamInfo { get; set; } = new BasicInfo();
        public int TeamTarget { get; set; } = 0;
        public int TeamScore { get; set; } = 0;
        public int TeamBalls { get; set; } = 0;
        public int TeamWickets { get; set; } = 0; //1, 2, 4, etc
        public int TeamFours { get; set; } = 0;
        public int TeamSixes { get; set; } = 0;
        public int TeamExtra { get; set; } = 0;
        public int TeamBonus { get; set; } = 0;
        public double CurrentRunRate { get; set; } = 0; //12, 25, 49, etc
        public double RequireRunRate { get; set; } = 0; //12, 25, 49, etc
        public int RemainingBalls { get; set; } = 0;
        public int PlayerRuns { get; set; } = 0;
        public int PlayerScore { get; set; } = 0;
        public int PlayerBalls { get; set; } = 0;
        public int PlayerFours { get; set; } = 0;
        public int PlayerSixes { get; set; } = 0;
        public int PlayerBoundariesInARow { get; set; } = 0;
        public int PlayerFoursInARow { get; set; } = 0;
        public int PlayerSixesInARow { get; set; } = 0;
        public double PlayerBatspeed { get; set; } = 0;
        public bool IsDefended { get; set; }
        public bool IsMissed { get; set; }
        public bool IsLeftAlone { get; set; }
        public bool IsBackFoot { get; set; }
        public bool IsEdge { get; set; }
        public bool IsOut { get; set; }
        public int HitDistance { get; set; } = 0;
        public int HitAngle { get; set; } = 0; // angle degree + height-distance
        public string HittingZone { get; set; } = string.Empty; // 0-11
        public string HittingArea { get; set; } = string.Empty; // straight, long-on, long-off, cover, 3rd man, etc
        public string ShotSelection { get; set; } = string.Empty; // straight-drive, cover-drive, square-drive, square-cut, pull, hook, sweep etc
        public bool IsReviewed { get; set; }
        public bool IsReviewLost { get; set; }
        public bool IsRetiredHurt { get; set; }
        public bool IsInjured { get; set; }
        public string InjuredReason { get; set; } = string.Empty;
        public int Minutes { get; set; } = 0;
        public string Milestone { get; set; } = string.Empty; // FIFTIES, HUNDREDS, DOUBLE-HUNDREDS, TRIPLE-HUNDREDS, 6SIXES, 6FOURS,
        public string Achievement { get; set; } = string.Empty; // 500RUNS, 1000RUNS, 2000RUNS, 5000RUNS & 100WICKETS, ETC
    }

    public class Bowling
    {
        public BasicInfo BowlerInfo { get; set; } = new BasicInfo();
        public BasicInfo TeamInfo { get; set; } = new BasicInfo();
        public bool IsWicketTaken { get; set; }
        public int Runs { get; set; } = 0;
        public int TotalDots { get; set; } = 0;
        public int TotalMaidens { get; set; } = 0;
        public int TotalRuns { get; set; } = 0;
        public int TotalBalls { get; set; } = 0;
        public int TotalWideBalls { get; set; } = 0;
        public int TotalNoBalls { get; set; } = 0;
        public int DotsInARow { get; set; } = 0;
        public int MaidensInARow { get; set; } = 0;
        public int WicketsInARow { get; set; } = 0;
        public int Wickets { get; set; } = 0;
        public double BallSpeed { get; set; } = 0;
        public string BowlingEnd { get; set; } = string.Empty; // left, right,
        public string BowlingSide { get; set; } = string.Empty; // round_the_wicket, around_the_wicket,
        public string BowlingArm { get; set; } = string.Empty; // left, right,
        public string BowlingAction { get; set; } = string.Empty; // pacer, spinner,
        public string BowlingStyle { get; set; } = string.Empty; // Leg, Off, Left Arm, Right Arm, Medium, etc
        public string BowlingType { get; set; } = string.Empty; // In Swing, Out Swing, Googly, Doosra, etc
        public string BallPitched { get; set; } = string.Empty; //(x, y) coordinate value
        public string BallLength { get; set; } = string.Empty; // good, full, short, yourker, half-holly, etc
        public bool IsInjured { get; set; }
        public string InjuredReason { get; set; } = string.Empty;
        public bool IsReviewed { get; set; }
        public bool IsMaidenBall { get; set; }
        public bool IsReviewLost { get; set; }
        public int Spells { get; set; } = 0;
        public string Milestone { get; set; } = string.Empty; // HAT-TRICK, FIFER
        public string Achievement { get; set; } = string.Empty; // 100WICKETS, 200WICKETS, 300WICKETS, 100WICKETS & 1000RUNS, ETC
    }

    public class Fielding
    {
        public BasicInfo FielderInfo { get; set; } = new BasicInfo();
        public string FielderPosition { get; set; } = string.Empty; //gully, silly, 1st-slip, 2nd-slip, keeping etc
        public bool IsInjured { get; set; }
        public string InjuredReason { get; set; } = string.Empty;
        public bool IsSubstituteFilder { get; set; }
        public bool IsCatchTaken { get; set; }
        public bool IsSloppyCatch { get; set; }
        public bool IsCombinedCatch { get; set; }
        public bool IsCatchDropped { get; set; }
        public bool IsRunOut { get; set; }
        public bool IsCombinedRunOut { get; set; }
        public bool IsRunOutMissed { get; set; }
        public bool IsMissFielding { get; set; }
        public bool IsOverThrow { get; set; }
        public bool IsExtraOrdinaryFielding { get; set; }
        public bool IsExtraOrdinaryCatch { get; set; }
        public string Milestone { get; set; } = string.Empty; // HAT-TRICK CATCHES, HAT-TRICK RUN-OUTS, HAT-TRICK STAMPINGS
        public string Achievement { get; set; } = string.Empty; // 200 CATCHES, 50 RUN-OUTS, 100 STAMPINGS
    }

    public class Umpiring
    {
        public BasicInfo UmpireInfo { get; set; } = new BasicInfo();
        public bool IsRequestedDoubleChecked { get; set; }
        public bool IsDecitionDoubleChecked { get; set; }
        public bool IsThirdUmpireCalled { get; set; }
        public bool IsGivenOut { get; set; }
        public bool IsReviewing { get; set; }
        public bool IsReviewOverturned { get; set; }
        public string ReviewOverview { get; set; } = string.Empty; // EDGE, HITTING WICKET, UMPIRE-CALL, MISSING-WICKET, NO-EDGE
        public string SoftSignal { get; set; } = string.Empty; // OUT / NOT OUT / None
        public bool IsInjured { get; set; }
        public string InjuredReason { get; set; } = string.Empty;
    }

    public class Commentating
    {
        public BasicInfo CommenterInfo { get; set; } = new BasicInfo();
        public string Comment { get; set; } = string.Empty;
        public string Speech { get; set; } = string.Empty;
    }

    public class WeatherForecast
    {
        public string WeatherCondition { get; set; } = string.Empty; // t29c; h35c; cloudy / rainy / sunny / clear;
        public bool IsFoggy { get; set; }
        public bool IsWetOutfield { get; set; }
    }
}
