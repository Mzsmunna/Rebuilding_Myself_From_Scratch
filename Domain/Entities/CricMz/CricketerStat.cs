using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class CricketerStat : IEntity
    {
        public string Id { get; set; } = string.Empty;
        public string UserID { get; set; } = string.Empty;
        public string CricketerID { get; set; } = string.Empty;
        public string CricketerName { get; set; } = string.Empty;
        public string CricketerImage { get; set; } = string.Empty;
        public string TeamID { get; set; } = string.Empty;
        public string TeamName { get; set; } = string.Empty;
        public string TeamImage { get; set; } = string.Empty;
        public int Matches { get; set; } = 0;
        public string MatchGenre { get; set; } = string.Empty; // Men / Women / Men_Special / Women_Special / Transgender / Others
        public string MatchType { get; set; } = string.Empty; // street, gully, rooftop, indoor, book, paper, local, area, national, international, league, franchise, friendly, charity
        public string MatchFormat { get; set; } = string.Empty; // Limited, ODI, ODI_40, TEST, TEST_4D, TEST_3D, T20I, T20, T10, SAS => Six_A_Site
        public BattingStat BattingStat { get; set; } = new BattingStat();
        public BowlingStat BowlingStat { get; set; } = new BowlingStat();
        public FieldingStat FieldingStat { get; set; } = new FieldingStat();
    }

    public class BattingStat
    {
        public int Innings { get; set; } = 0;
        public int Runs { get; set; } = 0;
        public int EdgedRuns { get; set; } = 0;
        public int Balls { get; set; } = 0;
        public int Best { get; set; } = 0;
        public double Average { get; set; } = 0;
        public double StrikeRate { get; set; } = 0;
        public int Misses { get; set; } = 0;
        public int LeftAlones { get; set; } = 0;
        public int Defends { get; set; } = 0;
        public int Edges { get; set; } = 0;
        public int Lucks { get; set; } = 0;
        public int Dots { get; set; } = 0;
        public int Ones { get; set; } = 0;
        public int Twos { get; set; } = 0;
        public int Threes { get; set; } = 0;
        public int Fours { get; set; } = 0;
        public int Fives { get; set; } = 0;
        public int Sixes { get; set; } = 0;
        public int Sevens { get; set; } = 0;
        public int FrontFoots { get; set; } = 0;
        public int BackFoots { get; set; } = 0;
        public int StepOuts { get; set; } = 0;
        public int Lofts { get; set; } = 0;
        public int B2BFours { get; set; } = 0;
        public int FoursX6 { get; set; } = 0;
        public int B2BSixes { get; set; } = 0;
        public int SixesX6 { get; set; } = 0;
        public int Fifties { get; set; } = 0;
        public int Nervous90 { get; set; } = 0;
        public int Nervous99 { get; set; } = 0;
        public int Centuries { get; set; } = 0;
        public int IICenturies { get; set; } = 0;
        public int IIICenturies { get; set; } = 0;
        public int IVCenturies { get; set; } = 0;
        public int VCenturies { get; set; } = 0;
        public int Ducks { get; set; } = 0;
        public int Outs { get; set; } = 0;
        public int NotOuts { get; set; } = 0;
        public int RunOuts { get; set; } = 0;
        public int Mankads { get; set; } = 0;
        public int Caughts { get; set; } = 0;
        public int Bolds { get; set; } = 0;
        public int LBWs { get; set; } = 0;
        public int HitWickets { get; set; } = 0;
        public int RetiredHurts { get; set; } = 0;
        public int Stumps { get; set; } = 0;
    }

    public class BowlingStat
    {
        public int Innings { get; set; } = 0;
        public int Balls { get; set; } = 0;
        public int WideBalls { get; set; } = 0;
        public int NoBalls { get; set; } = 0;
        public int HeightNoBalls { get; set; } = 0;
        public int SteppedNoBalls { get; set; } = 0;
        public int PanaltyNoBalls { get; set; } = 0;
        public int Unlucky { get; set; } = 0;
        public int Wickets { get; set; } = 0;
        public int Bowled { get; set; } = 0;
        public int LBW { get; set; } = 0;
        public int Caughts { get; set; } = 0;
        public int HitWickets { get; set; } = 0;
        public int RetiredHurts { get; set; } = 0;
        public int RunOuts { get; set; } = 0;
        public int Mankads { get; set; } = 0;
        public float Average { get; set; } = 0;
        public float Economy { get; set; } = 0;
        public string Best { get; set; } = string.Empty; // "45/6"
        public int Hattricks { get; set; } = 0;
        public int Maidens { get; set; } = 0;
        public int Runs { get; set; } = 0;
        public int Extras { get; set; } = 0;
        public int Dots { get; set; } = 0;
        public int Ones { get; set; } = 0;
        public int Twos { get; set; } = 0;
        public int Threes { get; set; } = 0;
        public int Fours { get; set; } = 0;
        public int Fives { get; set; } = 0;
        public int Sixes { get; set; } = 0;
        public int Sevens { get; set; } = 0;
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
        public int CombinedCatches { get; set; } = 0;
        public int CatchDropped { get; set; } = 0;
        public int SloppyCatches { get; set; } = 0;
        public int RunOuts { get; set; } = 0;
    }
}
