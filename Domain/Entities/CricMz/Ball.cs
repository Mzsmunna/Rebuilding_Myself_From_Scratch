using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class Ball : IEntity
    {
        public string ID { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public BallSummary BallSummary { get; set; } = new BallSummary();
        public ScoreSummary? ScoreSummary { get; set; } = new ScoreSummary(); // for historical score record after each ball

        public Commentating? Commentary { get; set; } = new Commentating();
        public Umpiring? StampUmpire { get; set; } = new Umpiring();
        public Umpiring? LegUmpire { get; set; } = new Umpiring();
        public Umpiring? TvUmpire { get; set; } = new Umpiring();
        public Umpiring? MatchRefree { get; set; } = new Umpiring();
        public Batting? StrikerBatsman { get; set; } = new Batting();
        public Batting? NonStrikerBatsman { get; set; } = new Batting();
        public Bowling? Bowler { get; set; } = new Bowling();
        public BasicInfo? FieldingSetupInfo { get; set; } = new BasicInfo();
        public Fielding? Fielder { get; set; } = new Fielding();
        public Fielding? AssistFielder { get; set; } = new Fielding();
        public Fielding? WicketKeeper { get; set; } = new Fielding();

        //public BasicInfo? ClipInfo { get; set; } = null;
        //public WeatherForecast? WeatherForecast { get; set; } = null;
        //public List<string> MomentIDs { get; set; } = new List<string>();

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; } = null;
        public string ModificationReason { get; set; } = string.Empty;
    }

    public class BallSummary
    {
        public int OverNo { get; set; }
        public int BallNo { get; set; } // max == BallPerOver
        public int Runs { get; set; } = 0;
        public string RunType { get; set; } = string.Empty; // dot, single, double, triple, boundary / four, over-boundary / six
        public bool IsOut { get; set; } = false;
        public string OutType { get; set; } = string.Empty; // RunOut, Caught, CaughtBehind, Caught&Bowled, Blowled, LBW, HitWicket, Stumped, Mankading, RetiredHurt, RetiredOut, TimedOut, HitBallTwice, ObstructingField, Absent
        public int Extras { get; set; } = 0;
        public string ExtraReason { get; set; } = string.Empty; // bye, leg_bye, wide, noball
        public string ExtraSpecificReason { get; set; } = string.Empty; // bye, leg_bye, wide-outside_leg, wide-outside-off, wide-height, noball-height, noball-overstepping, noball-max_bouncers, noball-fake_fielding, noball-fielding_rules_voilance
        public int BonusRuns { get; set; } = 0;
        public string BonusReason { get; set; } = string.Empty; // miss field, overthrow, overboundary, fake fielding, fielding rules voilance, hitting helmet on field etc
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

    public class ScoreSummary
    {
        public string MatchID { get; set; } = string.Empty;
        public string MatchGenre { get; set; } = string.Empty; // Men / Women / Men_Special / Women_Special / Transgender / Others
        public string MatchType { get; set; } = string.Empty; // street, gully, rooftop, indoor, book, paper, local, area, national, international, league, franchise, friendly, charity
        public string MatchFormat { get; set; } = string.Empty; // Limited, ODI, ODI_40, TEST, TEST_4D, TEST_3D, T20I, T20, T10, SAS => Six_A_Site
        public string BallType { get; set; } = string.Empty; // pingpong, sponge, plastic, rubber, tennis, tape_tennis, synthetic, hockey, cork, red_leather, white_leather, pink_leather, other
        public string PitchType { get; set; } = string.Empty; // rough, cement, turf, astroturf, matting, green, dry, dusty, flat_track, wet, dead
        public string MatchTitle { get; set; } = string.Empty;
        public BasicInfo TeamInfo { get; set; } = new BasicInfo();
        public BasicInfo OpponentInfo { get; set; } = new BasicInfo();

        public int TeamScore { get; set; } = 0;
        public int TeamWickets { get; set; } = 0;
        public int TeamBalls { get; set; } = 0;
        public int TeamCurrentRunRate { get; set; } = 0;
        public int TeamRequireRunRate { get; set; } = 0;
        public int TeamPreviousScore { get; set; } = 0;
        public int TeamPreviousWickets { get; set; } = 0;
        public int TeamPreviousBalls { get; set; } = 0;
        public int TeamPreviousRunRate { get; set; } = 0;
        public int OpponentScore { get; set; } = 0;
        public int OpponentWickets { get; set; } = 0;
        public int OpponentBalls { get; set; } = 0;
        public int OpponentRunRate { get; set; } = 0;
        public int OpponentPreviousScore { get; set; } = 0;
        public int OpponentPreviousWickets { get; set; } = 0;
        public int OpponentPreviousBalls { get; set; } = 0;
        public int OpponentPreviousRunRate { get; set; } = 0;
        public int Target { get; set; } = 0;
        public int RevisedTarget { get; set; } = 0;
        public bool IsTeamChasing { get; set; } = false;
    }

    public class Batting
    {
        public BasicInfo BatsmanInfo { get; set; } = new BasicInfo();
        public int Runs { get; set; } = 0;
        public int Score { get; set; } = 0;
        public int Balls { get; set; } = 0;
        public int Fours { get; set; } = 0;
        public int Sixes { get; set; } = 0;
        public double StrikeRate { get; set; } = 0;
        public int BoundariesInARow { get; set; } = 0;
        public int FoursInARow { get; set; } = 0;
        public int SixesInARow { get; set; } = 0;
        public double Batspeed { get; set; } = 0;
        public bool IsBackFoot { get; set; } = false;
        public bool IsStepOut { get; set; } = false;
        public bool IsLofted { get; set; } = false;
        public bool IsOut { get; set; } = false;
        public int HitDistance { get; set; } = 0;
        public string BattingHand { get; set; } = string.Empty; // left / right
        public string BattingAction { get; set; } = string.Empty; // Defended, Played & Missed, Played, Left Alone, Edged, Top Edged, Bottom Edged, Under Edged, Gloved
        public int HitAngle { get; set; } = 0; // angle degree + height-distance
        public string HittingZone { get; set; } = string.Empty; // 0-11
        public string HittingArea { get; set; } = string.Empty; // straight, long-on, long-off, cover, 3rd man, etc
        public string ShotSelection { get; set; } = string.Empty; // straight-drive, cover-drive, square-drive, square-cut, pull, hook, sweep etc
        public bool IsReviewed { get; set; } = false;
        public string ReviewedFor { get; set; } = string.Empty; // no-ball, wide, not-out, etc
        public bool IsReviewLost { get; set; } = false;
        public bool IsRetiredHurt { get; set; } = false;
        public bool IsInjured { get; set; } = false;
        public string InjuredReason { get; set; } = string.Empty;
        public int Minutes { get; set; } = 0;
        public string Milestone { get; set; } = string.Empty; // FIFTIES, HUNDREDS, DOUBLE-HUNDREDS, TRIPLE-HUNDREDS, 6SIXES, 6FOURS,
        public string Achievement { get; set; } = string.Empty; // 500RUNS, 1000RUNS, 2000RUNS, 5000RUNS & 100WICKETS, ETC
    }

    public class Bowling
    {
        public BasicInfo BowlerInfo { get; set; } = new BasicInfo();
        public bool IsWicketTaken { get; set; } = false;
        public int RunsConsumed { get; set; } = 0;
        public int RunsGiven { get; set; } = 0;
        public int Wickets { get; set; } = 0;
        public double Economy { get; set; } = 0;
        public int TotalDots { get; set; } = 0;
        public int TotalMaidens { get; set; } = 0;
        public int TotalBalls { get; set; } = 0;
        public int TotalWideBalls { get; set; } = 0;
        public int TotalNoBalls { get; set; } = 0;
        public int DotsInARow { get; set; } = 0;
        public int MaidensInARow { get; set; } = 0;
        public int WicketsInARow { get; set; } = 0;
        public double BallSpeed { get; set; } = 0;
        public string BowlingEnd { get; set; } = string.Empty; // left, right,
        public string BowlingSide { get; set; } = string.Empty; // round_the_wicket, around_the_wicket,
        public string BowlingArm { get; set; } = string.Empty; // left, right,
        public string BowlingAction { get; set; } = string.Empty; // pacer, spinner,
        public string BowlingStyle { get; set; } = string.Empty; // Leg, Off, Left Arm, Right Arm, Medium, etc
        public string BowlingType { get; set; } = string.Empty; // In Swing, Out Swing, Googly, Doosra, etc
        public string BallPitched { get; set; } = string.Empty; //(x, y) coordinate value
        public string BallLength { get; set; } = string.Empty; // good, full, short, yourker, half-holly, etc
        public bool IsInjured { get; set; } = false;
        public string InjuredReason { get; set; } = string.Empty;
        public bool IsReviewed { get; set; } = false;
        public string ReviewedFor { get; set; } = string.Empty; // no-ball, wide, out, etc
        public bool IsMaidenBall { get; set; } = false;
        public bool IsReviewLost { get; set; } = false;
        public int Spells { get; set; } = 0;
        public string Milestone { get; set; } = string.Empty; // HAT-TRICK, FIFER
        public string Achievement { get; set; } = string.Empty; // 100WICKETS, 200WICKETS, 300WICKETS, 100WICKETS & 1000RUNS, ETC
    }

    public class Fielding
    {
        public BasicInfo FielderInfo { get; set; } = new BasicInfo();
        public string FielderPosition { get; set; } = string.Empty; // gully, silly, 1st-slip, 2nd-slip, keeping etc
        public string FieldingHand { get; set; } = string.Empty;
        public string FieldingAction { get; set; } = string.Empty; // No chance, Attempted, Runs Saved, Boundary Saved, Overboundary Saved, Cought, Cought & Bowled, Caught Behind, Catch Dropped, Miss Fielding, Overthrow, Run Out, Direct Run Out, Combined Run Out, Missed Run Out
        public bool IsSubstituteFilder { get; set; } = false;
        public bool IsInjured { get; set; } = false;
        public string InjuredReason { get; set; } = string.Empty;
        public int FumbleCount { get; set; } = 0;
        public bool IsExtraOrdinaryFielding { get; set; } = false;
        public bool IsExtraOrdinaryCatch { get; set; } = false;
        public string Milestone { get; set; } = string.Empty; // HAT-TRICK CATCHES, HAT-TRICK RUN-OUTS, HAT-TRICK STAMPINGS
        public string Achievement { get; set; } = string.Empty; // 200 CATCHES, 50 RUN-OUTS, 100 STAMPINGS
    }

    public class Umpiring
    {
        public BasicInfo UmpireInfo { get; set; } = new BasicInfo();
        public bool IsRequestedDoubleChecked { get; set; } = false;
        public bool IsDecitionDoubleChecked { get; set; } = false;
        public bool IsThirdUmpireCalled { get; set; } = false;
        public bool IsGivenOut { get; set; } = false;
        public bool IsReviewing { get; set; } = false;
        public bool IsReviewOverturned { get; set; } = false;
        public string ReviewOverview { get; set; } = string.Empty; // EDGE, HITTING WICKET, UMPIRE-CALL, MISSING-WICKET, NO-EDGE
        public string SoftSignal { get; set; } = string.Empty; // OUT / NOT OUT / None
        public bool IsInjured { get; set; } = false;
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
        public double Temperature { get; set; } = 0; // in F
        public double Humidity { get; set; } = 0; // in F
        public string Condition { get; set; } = string.Empty; // cloudy / rainy / sunny / clear;
        public bool IsFoggy { get; set; } = false;
        public bool IsWetOutfield { get; set; } = false;
    }
}
