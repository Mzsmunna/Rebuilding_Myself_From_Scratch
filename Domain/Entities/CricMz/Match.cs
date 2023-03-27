using Domain.Entities;
using Domain.Enums.CricMz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Domain.Entities.CricMz
{
    public class Match : IEntity
    {
		public string ID { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string Title { get; set; } = string.Empty;
        public string MatchTypes { get; set; } = string.Empty;
        public string MatchFormats { get; set; } = string.Empty;
        public int MatchNo { get; set; } = 1;

        public MatchConfig MatchConfig { get; set; } = new MatchConfig();
        public BasicInfo TournamentInfo { get; set; } = new BasicInfo();
        public BasicInfo SeriesInfo { get; set; } = new BasicInfo();
        public BasicInfo StadiumInfo { get; set; } = new BasicInfo();
        public BasicInfo FirstUmpireInfo { get; set; } = new BasicInfo();
        public BasicInfo SecondUmpireInfo { get; set; } = new BasicInfo();
        public BasicInfo TvUmpireInfo { get; set; } = new BasicInfo();
        public BasicInfo MatchRefreeInfo { get; set; } = new BasicInfo();

        public Squad HomeTeam { get; set; } = new Squad();
        public Squad AwayTeam { get; set; } = new Squad();

        public BasicInfo? ManOfMatch { get; set; } = null;
        public BasicInfo? ManOfSeries { get; set; } = null;
        public BasicInfo? ManOfTournament { get; set; } = null;
        public List<Award>? OtherAwards { get; set; } = null;
        public string MatchResult { get; set; } = string.Empty;
        public string MatchWinsBy { get; set; } = string.Empty; // Runs / Wickets
        public bool IsDLSApplied { get; set; }

        public string TossWinTeamID { get; set; } = string.Empty; // Team ID
        public string WinningTeamID { get; set; } = string.Empty; // Team ID
        public string TossDecition { get; set; } = string.Empty; // 'Bat' / 'Bowl' or 'Fielding'
        public string WeatherCondition { get; set; } = string.Empty; // t29c; h35c; cloudy / rainy / sunny / clear;
        public bool IsMatchInterrupted { get; set; }
        public bool IsMatchInterruptReason { get; set; } // Rain,
        public bool IsInterruptedByRain { get; set; }
        public bool IsMatchAbandoned { get; set; }
        public bool IsMatchStarted { get; set; }
        public bool IsMatchFinished { get; set; }
        public bool IsMatchTied { get; set; }
        public bool IsDRSApplied { get; set; }
        public DateTime MatchStartedAt { get; set; }
        public DateTime MatchResumedAt { get; set; }
        public DateTime MatchEndedAt { get; set; }


	    //- List<Balls>
 
	    //- Stats(Most runs, wickets, etc)
	    //- TeamA -> {
     //   } 
	    //- TeamB-> {[Squard] , [Playing XI] , [Bench] , [Batting] , [Bowling]
    }
    //-ScoreCard: { }
    //-HostTeamID:
    //	-DRS;
    //-Highlights:
    //	-Bet(in future)
    //    - User friendly Adds
    //	- better / unique animations (in future) 
    //	-News Feeds(Blogs, Vlogs, Content, Memes, Posts)[in future]
    //    }

    public class MatchConfig
    {
        public string ID { get; set; } = string.Empty;
        public string TossType { get; set; } = string.Empty; // CoinFlip, BatFlip, Numbering, BlindNamePickForNumber,
        public string Type { get; set; } = string.Empty; // street, gully, rooftop, indoor, book, paper, local, area, national, international, league, franchise, friendly, charity
        public string Format { get; set; } = string.Empty; // Limited, ODI, ODI_40, TEST, TEST_4D, TEST_3D, T20I, T20, T10, SAS => Six_A_Site
        public string PlayType { get; set; } = string.Empty; // short_pitch, long_pitch
        public string BallType { get; set; } = string.Empty; // pingpong, sponge, plastic, rubber, tennis, tape_tennis, synthetic, hockey, cork, red_leather, white_leather, pink_leather, other
        public string BallBrand { get; set; } = string.Empty; // kookaburra, duke, sg
        public string PitchType { get; set; } = string.Empty; // rough, cement, turf, astroturf, matting, green, dry, dusty, flat_track, wet, dead
        public bool IsSolo { get; set; } = false;
        public int MaxOver { get; set; } = 10; // 450 => TEST
        public int MaxBallInOver { get; set; } = 6;
        public int MaxPlayerInTeam { get; set; } = 11;
        public List<Powerplay>? Powerplays { get; set; } = new List<Powerplay> (); // Max length 3; 
        public CustomConfig? CustomConfig { get; set; } = null;
        public bool AllowBatterSwitchOnOut { get; set; } = true;
        public bool AllowSlowOverRate { get; set; } = true;
        public bool AllowDLS { get; set; } = false;
        public bool HasDRS { get; set; } = false;
        public bool HasHotSpot { get; set; } = false;
        public bool HasHawkEye { get; set; } = false;
        public bool HasSnickoMeter { get; set; } = false;
        public bool HasStumpMic { get; set; } = false;
        public bool HasBroadcastRights { get; set; } = false;
        public string BroadcastingOn { get; set; } = string.Empty; //"GTV, TSPORTS, RABBITHOLEBD, YOUTUBE" urls
        public int MaxFieldersInCircle { get; set; } = 11;
        public int MaxFieldersOffCircle { get; set; } = 5;
    }

    public class CustomConfig
    {
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
        public bool AllowTeamBalance { get; set; } = true;
        public bool AllowPlayerReplacement { get; set; } = false;
        public bool AllowPlayerInBothTeam { get; set; } = false;
        public bool AllowMultiStyleBatting { get; set; } = false;
        public bool AllowMultiStyleBowling { get; set; } = false;
        public bool AllowPaceBowling { get; set; } = true;
        public bool AllowDualBatting { get; set; } = true;
        public bool AllowLastMan { get; set; } = false;
        public bool AllowKeeping { get; set; } = true;
        public bool AllowKeeperSwitch { get; set; } = true;
        public bool AllowBatterSwitchOnOver { get; set; } = true;
        public List<DisabledZone>? DisabledZones { get; set; } = null; // Max length 6;
    }

    //public class LegacyConfig
    //{
    //    public bool AllowBatterSwitchOnOut { get; set; } = true;
    //}

    public class Powerplay
    {
        public int FromOver { get; set; } = 1; //ODI => 1, 11, 41; T20 => 1, 7
        public int ToOver { get; set; } = 10; //ODI => 10, 40, 50; T20 => 6, 20
        public int? MaxFieldersInCircle { get; set; } = 11;
        public int? MaxFieldersOffCircle { get; set; } = 5;
    }

    public class DisabledZone
    {    
        public int Zone { get; set; } = 0; // MIN => 0, Max => 11
        public string Reason { get; set; } = string.Empty; // wall, pond, pool, building, garadge, garden, muddy, roof, car-paking, street, highway, other
        public string SpecificReason { get; set; } = string.Empty;
    }
}
