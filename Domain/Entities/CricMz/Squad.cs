using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class Squad
    {
        public string TeamID { get; set; } = string.Empty;
        public string TeamName { get; set; } = string.Empty;

        public int Runs { get; set; } = 0;
        public int Extras { get; set; } = 0;
        public int WicketsFallen { get; set; } = 0;

        public List<string> FallOfWickets { get; set; }
        public List<Partnership> Partnerships { get; set; }

        public List<string> AvailablePlayers { get; set; } // PlayerIds
        public List<string> PlayingXI { get; set; } // PlayerIds
        public List<string> Bench { get; set; } // PlayerIds
        public List<string> Batters { get; set; } // PlayerIds
        public List<string> Bowlers { get; set; } // PlayerIds
        public List<string> Allrounders { get; set; } // PlayerIds
    }

    public class Player
    {
        public string CricketerID { get; set; } = string.Empty;
        public string ProfileID { get; set; } = string.Empty;
        public string PlayerName { get; set; } = string.Empty;
    }

    public class Performance
    {
        public string PlayerID { get; set; } = string.Empty;
        public string PlayerName { get; set; } = string.Empty;
        public Batting BattingPerformance { get; set; }
        public Bowling BowlingPerformance { get; set; }
        public Fielding FieldingPerformance { get; set; }
    }

    public class Partnership
    {
        public string FirstPlayerID { get; set; } = string.Empty;
        public string FirstPlayerName { get; set; } = string.Empty;
        public int FirstPlayerContribution { get; set; } = 0;
        public string SecondPlayerID { get; set; } = string.Empty;
        public string SecondPlayerName { get; set; } = string.Empty;
        public int SecondPlayerContribution { get; set; } = 0;
        public int TotalContributions { get; set; } = 0;
        public int? WicketFallen { get; set; } = null;
    }

    public class Batting
    {
        public int Runs { get; set; } = 0;
        public int Balls { get; set; } = 0;
        public int Fours { get; set; } = 0;
        public int Sixes { get; set; } = 0;
        public float StrikeRate { get; set; } = 0;
        public bool IsNotOut { get; set; } = false;
        public bool IsOut { get; set; } = false;
        public bool IsRunOut { get; set; } = false;
        public bool IsCaught { get; set; } = false;
        public bool IsBold { get; set; } = false;
        public bool IsLBW { get; set; } = false;
        public bool IsHitWicket { get; set; } = false;
        public bool IsRetiredHurt { get; set; } = false;
        public bool IsStumped { get; set; } = false;
        public int GotLucky { get; set; } = 0;
        public string CaughtByID { get; set; } = string.Empty;
        public string RunOutByID { get; set; } = string.Empty;
        public string StumpingID { get; set; } = string.Empty;
        public string WicketTakerID { get; set; } = string.Empty;
    }

    public class Bowling
    {
        public int Wickets { get; set; } = 0;
        public int Runs { get; set; } = 0;
        public int Balls { get; set; } = 0;
        public int Fours { get; set; } = 0;
        public int Sixes { get; set; } = 0;
        public float EconomyRate { get; set; } = 0;
        public int Bowled { get; set; } = 0;
        public int LBWS { get; set; } = 0;
        public int HitWickets { get; set; } = 0;
        public int RetiredHurts { get; set; } = 0;
        public int GotUnlucky { get; set; } = 0;
    }

    public class Fielding
    {
        public int RunOuts { get; set; } = 0;
        public int MissedRunOuts { get; set; } = 0;
        public int Catches { get; set; } = 0;
        public int DroppedCatches { get; set; } = 0;
        public int Stumpings { get; set; } = 0;
        public string CatchTakenIDs { get; set; } = string.Empty; //"id,id..."
        public string RunOutByID { get; set; } = string.Empty;
        public string WicketTakerID { get; set; } = string.Empty;
    }
}
