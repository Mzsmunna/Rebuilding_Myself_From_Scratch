using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class ScoreCard : Score
    {
        public double CurrentRunRate { get; set; } = 0;
        public double RequireRunRate { get; set; } = 0;
        public List<Partnership> Partnerships { get; set; } = new List<Partnership>();
    }

    public class Partnership
    {
        //public string TeamID { get; set; } = string.Empty;
        public string FirstPlayerID { get; set; } = string.Empty;
        public int FirstPlayerContribution { get; set; } = 0;
        public string SecondPlayerID { get; set; } = string.Empty;
        public int SecondPlayerContribution { get; set; } = 0;
        public int TotalContributions { get; set; } = 0;
        public bool IsUnbroken { get; set; } = false;
        public int? FallOfWickets { get; set; } = null;
        public int WicketsNo { get; set; } = 1;
        public string OutType { get; set; } = string.Empty; //RunOut, Caught, Bold, LBW, HitWicket, Stumped
        public string BowlerID { get; set; } = string.Empty;
        public string FielderID { get; set; } = string.Empty;
        public string AssistFielderID { get; set; } = string.Empty;
        public string WicketKeeperID { get; set; } = string.Empty;
    }
}
