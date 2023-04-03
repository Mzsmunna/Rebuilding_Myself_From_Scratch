using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class Cricketer : IEntity
    {
        public string ID { get; set; } = string.Empty;
        public string UserID { get; set; } = string.Empty;
        public string ShadowUserID { get; set; } = string.Empty;
        public string CricketerStatsID { get; set; } = string.Empty;
        public CricketerInfo CricketerInfo { get; set; } = new CricketerInfo();
        
    }

    public class CricketerInfo : IEntity
    {
        public string CricketerName { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public string TitleName { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public float Height { get; set; } = 0;
        public float Weight { get; set; } = 0;
        public DateTime? DOB { get; set; } = null;
        public BirthInfo? BirthInfo { get; set; }
        public string Nationality { get; set; } = string.Empty; //","
        public string Teams { get; set; } = string.Empty; //","
        public string TeamIds { get; set; } = string.Empty; //","
        public string Role { get; set; } = string.Empty; //","
    }

    public class CricketerStat : IEntity
    {
        public string ID { get; set; } = string.Empty;
        public string CricketerID { get; set; } = string.Empty;
    }

    public class CricketingStat
    {
        public int Matches { get; set; } = 0;
        public string TeamID { get; set; } = string.Empty;
        public string TeamName { get; set; } = string.Empty;

        public BattingStat BattingStat { get; set; }
        public BowlingStat BowlingStat { get; set; }
        public FieldingStat FieldingStat { get; set; }
    }

    public class Batter
    {
        public BasicInfo BatterInfo { get; set; } = new BasicInfo();
        public int Matches { get; set; } = 0;
        public int Innings { get; set; } = 0;
        public int TotalRuns { get; set; } = 0;
        public int TotalBallFaced { get; set; } = 0;
        public int Runs { get; set; } = 0;
        public int BallFaced { get; set; } = 0;
        public int Best { get; set; } = 0;
        public float Average { get; set; } = 0;
        public float StrikeRate { get; set; } = 0;
        public int Ones { get; set; } = 0;
        public int Twos { get; set; } = 0;
        public int Threes { get; set; } = 0;
        public int Fours { get; set; } = 0;
        public int Sixes { get; set; } = 0;
        public int Fifties { get; set; } = 0;
        public int Centuries { get; set; } = 0;
    }

    public class BattingStat
    {
        public int Innings { get; set; } = 0;
        public int Runs { get; set; } = 0;
        public int EdgeRuns { get; set; } = 0;
        public int Best { get; set; } = 0;
        public float Average { get; set; } = 0;
        public float StrikeRate { get; set; } = 0;

        public int Misses { get; set; } = 0;
        public int LeftAlones { get; set; } = 0;
        public int Defends { get; set; } = 0;
        public int Edges { get; set; } = 0;
        public int Ones { get; set; } = 0;
        public int Twos { get; set; } = 0;
        public int Threes { get; set; } = 0;
        public int Fours { get; set; } = 0;
        public int FoursX6 { get; set; } = 0;
        public int B2BFours { get; set; } = 0;
        public int Sixes { get; set; } = 0;
        public int SixesX6 { get; set; } = 0;
        public int B2BSixes { get; set; } = 0;
        public int Fifties { get; set; } = 0;
        public int Nervous90 { get; set; } = 0;
        public int Nervous99 { get; set; } = 0;
        public int Centuries { get; set; } = 0;
        public int IICenturies { get; set; } = 0;
        public int IIICenturies { get; set; } = 0;
        public int IVCenturies { get; set; } = 0;
        public int VCenturies { get; set; } = 0;

        public int Lucks { get; set; } = 0;
        public int Ducks { get; set; } = 0;
        public int Outs { get; set; } = 0;
        public int NotOuts { get; set; } = 0;
        public int RunOuts { get; set; } = 0;
        public int Caughts { get; set; } = 0;
        public int Bolds { get; set; } = 0;
        public int LBWs { get; set; } = 0;
        public int HitWickets { get; set; } = 0;
        public int RetiredHurts { get; set; } = 0;
        public int Stumps { get; set; } = 0;

        //public string CaughtByIDs { get; set; } = string.Empty;
        //public string RunOutByIDs { get; set; } = string.Empty;
        //public string StumpingIDs { get; set; } = string.Empty;
        //public string WicketTakerIDs { get; set; } = string.Empty;
    }

    public class BowlingStat
    {
        public int Innings { get; set; } = 0;
        public int Wickets { get; set; } = 0;
        public float Average { get; set; } = 0;
        public float Economy { get; set; } = 0;
        public string Best { get; set; } = string.Empty;

        public int Dots { get; set; } = 0;
        public int Runs { get; set; } = 0;
        public int ExtraRuns { get; set; } = 0;
        public int Wides { get; set; } = 0;
        public int NoBalls { get; set; } = 0;
        public int HNoBalls { get; set; } = 0;
        public int SNoBalls { get; set; } = 0;
        public int Ones { get; set; } = 0;
        public int Twos { get; set; } = 0;
        public int Threes { get; set; } = 0;
        public int Fours { get; set; } = 0;
        public int Sixes { get; set; } = 0;
    }

    public class FieldingStat
    {
        public int Innings { get; set; } = 0;
        public string FieldingPositions { get; set; } = string.Empty; //","
        public int RunsSaved { get; set; } = 0;
        public int RunsCouldSave { get; set; } = 0;
        public int ExtraRunsGiven { get; set; } = 0;
        public int MissFieldings { get; set; } = 0;
        public int OverThrows { get; set; } = 0;
        public int ExtraOrdinaryFieldings { get; set; } = 0;
        public int ExtraOrdinaryCatches { get; set; } = 0;
        public int Catches { get; set; } = 0;
        public int CatchDropped { get; set; } = 0;
        public int SloppyCatches { get; set; } = 0;
        public int RunOuts { get; set; } = 0;
    }
}
