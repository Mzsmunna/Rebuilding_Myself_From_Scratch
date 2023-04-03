using Domain.Entities;
using Domain.Enums.CricMz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
//using static System.Reflection.Metadata.BlobBuilder;

namespace Domain.Entities.CricMz
{
    public class Match : IEntity
    {
		public string ID { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        public MatchConfig Config { get; set; } = new MatchConfig();
        public TossDetails? TossDetails { get; set; } = new TossDetails();
        public MatchResult? ResultDetails { get; set; } = new MatchResult();
        public BasicInfo? TournamentInfo { get; set; } = null;
        public BasicInfo? SeriesInfo { get; set; } = null;
        public BasicInfo? StadiumInfo { get; set; } = null;
        public BasicInfo? HostInfo { get; set; } = null;
        public BasicInfo? FirstUmpireInfo { get; set; } = null;
        public BasicInfo? SecondUmpireInfo { get; set; } = null;
        public BasicInfo? TvUmpireInfo { get; set; } = null;
        public BasicInfo? MatchRefreeInfo { get; set; } = null;

        public MatchSummary Summary { get; set; } = new MatchSummary();
        public Squard HomeTeam { get; set; } = new Squard();
        public Squard AwayTeam { get; set; } = new Squard();
        public DateTime StartTime { get; set; } = DateTime.UtcNow;
        public DateTime? EndTime { get; set; } = null;





        //- List<Balls>

        //- Stats(Most runs, wickets, etc)
        //- TeamA -> {
        //   } 
        //- TeamB-> {[Squard] , [Playing XI] , [Bench] , [Batting] , [Bowling]
    }
    //-Highlights:
    //- User friendly Adds
    //- better / unique animations (in future) 
    //-News Feeds(Blogs, Vlogs, Content, Memes, Posts)[in future]

    public class TossDetails
    {
        public string CoinFlippedTeamID { get; set; } = string.Empty; // Team ID
        public string CoinSidePickerTeamID { get; set; } = string.Empty; // Head / Tails
        public string CoinSide { get; set; } = string.Empty; // Head / Tails
        public string CoinSidePicked { get; set; } = string.Empty; // Head / Tails
        public string TossWinTeamID { get; set; } = string.Empty; // Team ID
        public string TossDecition { get; set; } = string.Empty; // 'Bat' / 'Bowl' or 'Fielding'
    }

    public class MatchSummary
    {
        public bool OnLive { get; set; } = false;
        public bool IsEnded { get; set; } = false;
        public int DayNo { get; set; } = 1;
        public ScoreBoard HomeTeam { get; set; } = new ScoreBoard();
        public ScoreBoard AwayTeam { get; set; } = new ScoreBoard();
        public int Target { get; set; } = 0;
        public int RevisedTarget { get; set; } = 0;
        public string Toss { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public string WinningTeamID { get; set; } = string.Empty; // Team ID
        public string ManOfMatchID { get; set; } = string.Empty;
        public string ManOfSeriesID { get; set; } = string.Empty;
        public string ManOfTournamentID { get; set; } = string.Empty;
        public string GameChangerOfMatchID { get; set; } = string.Empty;
        public string ValuablePlayerOfMatchID { get; set; } = string.Empty;
        public string ImpactPlayerOfMatchID { get; set; } = string.Empty;
        public string MostRunScorerID { get; set; } = string.Empty;
        public string MostWicketTakerID { get; set; } = string.Empty;
        public string BestAllRoundingPerformerID { get; set; } = string.Empty;
    }

    public class MatchResult
    {
        public bool IsMatchAbandoned { get; set; } = false;
        public bool IsMatchStarted { get; set; } = false;
        public bool IsMatchFinished { get; set; } = false;
        public bool IsMatchTied { get; set; } = false;
        public bool IsWinByRun { get; set; } = true;
        public bool IsDLSApplied { get; set; } = false;
        public bool IsMatchInterrupted { get; set; } = false;
        public string MatchInterruptReason { get; set; } = string.Empty; // Rain, Low-SunLight, Low-FloodLight, Wet-Outfield, etc
        public string WeatherCondition { get; set; } = string.Empty; // t29c; h35c; cloudy / rainy / sunny / clear;
    }

    public class MatchConfig
    {
        public string TossType { get; set; } = string.Empty; // CoinFlip, BatFlip, Numbering, BlindNamePickForNumber,
        public string MatchType { get; set; } = string.Empty; // street, gully, rooftop, indoor, book, paper, local, area, national, international, league, franchise, friendly, charity
        public string MatchFormat { get; set; } = string.Empty; // Limited, ODI, ODI_40, TEST, TEST_4D, TEST_3D, T20I, T20, T10, SAS => Six_A_Site
        public string BallType { get; set; } = string.Empty; // pingpong, sponge, plastic, rubber, tennis, tape_tennis, synthetic, hockey, cork, red_leather, white_leather, pink_leather, other
        public string PitchType { get; set; } = string.Empty; // rough, cement, turf, astroturf, matting, green, dry, dusty, flat_track, wet, dead
        public int MaxBalls { get; set; } = 60; // 50 over * 6 balls per over = 300 total balls in ODI, 20 * 6 = 120 in T20, 10 * 6 = 60 in T10, etc
        public int AllBowlersMaxBalls { get; set; } = 12; // 0 => Infinity (TEST), 10*6=60 in ODI, 4*6=24 in T20, 2*6=12 in T10
        public string BallBrand { get; set; } = string.Empty; // kookaburra, duke, sg
        public int BallsPerOver { get; set; } = 6; // Max =  6 / 5 / CUSTOM
        public int PlayerPerTeam { get; set; } = 11; // Min => 5 ?
        public OfficialConfig? OfficialConfig { get; set; } = null;
        public MatchRules MatchRules { get; set; } = new MatchRules();
    }

    public class MatchRules
    {
        public int MaxReplacementAllowed { get; set; } = 0; // When injued or player is not available
        public int MaxSubstituteAllowed { get; set; } = 0; // Impact Player in IPL 2023
        public int MaxFieldersInCircle { get; set; } = 11;
        public int MaxFieldersOffCircle { get; set; } = 5;
        public ConventionalRules? ConventionalRules { get; set; } = null;
        public UnconventionalRules? UnconventionalRules { get; set; } = null;
        public List<CustomRule>? CustomRules { get; set; } = new List<CustomRule>();
        public List<Powerplay>? Powerplays { get; set; } = new List<Powerplay>(); // Max length 3;
        public Reductions? Reductions { get; set; } = null;
    }

    public class OfficialConfig
    {
        public bool HasDRS { get; set; } = false;
        public bool HasHotSpot { get; set; } = false;
        public bool HasHawkEye { get; set; } = false;
        public bool HasSnickoMeter { get; set; } = false;
        public bool HasStumpMic { get; set; } = false;
        public bool HasBroadcastRights { get; set; } = false;
        public string BroadcastingOn { get; set; } = string.Empty; //"GTV, TSPORTS, RABBITHOLEBD, YOUTUBE, etc" urls
    }

    public class ConventionalRules
    {
        public bool AllowBatterSwitchOnCatchOut { get; set; } = false; // is always false under the new rules of ICC
        public bool AllowBatterSwitchAfterOver { get; set; } = true;
        public bool AllowSlowOverRate { get; set; } = false;
        public bool AllowDLS { get; set; } = false;
        public bool AllowPlayerUnfairMovement { get; set; } = false;
        public bool AllowBonusUponPanalty { get; set; } = false;
    }

    public class UnconventionalRules
    {
        public bool IsSoloMatch { get; set; } = false;
        public bool AllowPaceBowling { get; set; } = true;
        public bool AllowDualBatting { get; set; } = true;
        public bool AllowLastMan { get; set; } = false;
        public bool AllowKeeping { get; set; } = true;
        public bool AllowKeeperSwitch { get; set; } = true;
        public bool AllowTeamBalance { get; set; } = true;
        public bool AllowTryBall { get; set; } = false;
        public bool AllowLBW { get; set; } = true;
        public bool AllowCaughtBehind { get; set; } = true;
        public bool AllowHitWicket { get; set; } = true;
        public bool AllowRetiredHurt { get; set; } = true;
        public bool AllowRetiredOut { get; set; } = true;
        public bool AllowMancading { get; set; } = true;
        public bool AllowSingle { get; set; } = true;
        public bool AllowDouble { get; set; } = true;
        public bool AllowTriple { get; set; } = true;
        public bool AllowFour { get; set; } = true;
        public bool AllowSix { get; set; } = true;
        public bool AllowNoBall { get; set; } = true;
        public bool AllowHeightNoBall { get; set; } = true;
        public bool AllowWideBall { get; set; } = true;
        public bool AllowHeightWideBall { get; set; } = true;
        public bool AllowExtraRun { get; set; } = true;
        public bool AllowByeRun { get; set; } = true;
        public bool AllowLegByeRun { get; set; } = true;
        public bool AllowFreeHit { get; set; } = true;
        public bool AllowPlayingForBothTeam { get; set; } = false;
        public bool AllowMultiStyleBatting { get; set; } = false;
        public bool AllowMultiStyleBowling { get; set; } = false;
        public List<DisabledZone>? DisabledZones { get; set; } = null; // Max length 6;
    }

    public class CustomRule
    {
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Logic { get; set; } = string.Empty;
        public string ImpactsOn { get; set; } = string.Empty; // Batting / Balling / Fielding / Player / Batter / Bowler / Fielder / Team
    }

    public class Powerplay
    {
        public int FromOver { get; set; } = 1; //ODI => 1, 11, 41; T20 => 1, 7
        public int ToOver { get; set; } = 10; //ODI => 10, 40, 50; T20 => 6, 20
        public int? InCircleMaxFielders { get; set; } = 11;
        public int? OffCircleMaxFielders { get; set; } = 5;
    }

    public class DisabledZone
    {    
        public int Zone { get; set; } = 0; // MIN => 0, Max => 11
        public string Reason { get; set; } = string.Empty; // wall, pond, pool, building, garadge, garden, muddy, roof, car-paking, street, highway, other
        public string SpecificReason { get; set; } = string.Empty;
    }

    public class Reductions
    {
        public int MaxBalls { get; set; } = 0; // 8*6, 18*6, 27*6, 35*6, etc
        public int BallsPerOver { get; set; } = 0; // 5, 4, 3, etc
        public int AllBowlersMaxBalls { get; set; } = 0; // 6*6
        public int OneBowlerMaxBalls { get; set; } = 0; // 8*6
        public int TwoBowlersMaxBalls { get; set; } = 0; // 7*6
        public int ThreeBowlersMaxBalls { get; set; } = 0; // 6*6
        public int FourBowlersMaxBalls { get; set; } = 0; // 5*6
    }
}
