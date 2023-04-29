using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class Cricketer : IEntity
    {
        public string Id { get; set; } = string.Empty;
        public string UserID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty; // Mamunuz zaman sarker
        public string Title { get; set; } = string.Empty; // Mzs || Mzsmunna
        public string Gender { get; set; } = string.Empty; // male / female / transgender / other
        public int Age { get; set; } = 0;
        public double Height { get; set; } = 0;
        public double Weight { get; set; } = 0;
        public bool IsLeftie { get; set; } = false;
        public string Role { get; set; } = string.Empty;
        public string BattingHand { get; set; } = string.Empty; // left / right
        public string BattingOrder { get; set; } = string.Empty; // Top-Order, Middle-Order, 
        public string BowlingArm { get; set; } = string.Empty; // left, right,
        public string BowlingAction { get; set; } = string.Empty; // pacer, spinner,
        public string BowlingStyle { get; set; } = string.Empty; // Leg, Off, Left Arm, Right Arm, Medium, etc
        public string FielderPositions { get; set; } = string.Empty; // gully, silly, 1st-slip, 2nd-slip, keeping etc
        public string FieldingHand { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; } = null;
        public DateTime? DeathDate { get; set; } = null;
        public string Nationality { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string CoverImage { get; set; } = string.Empty;
        public List<TeamInfo> Teams { get; set; } = new List<TeamInfo>();
    }

    public class TeamInfo
    {
        public string Id { get; set; } = string.Empty;
        public string Identity { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty; // BAN, ENG, CSK, MI, etc
        public string Type { get; set; } = string.Empty; // International, National, Domestic, Franchise, Local, Street, Gully, Indoor
        public string Nationality { get; set; } = string.Empty;
        public string Roles { get; set; } = string.Empty; // "Captain,Opener-Batsman"
        public bool IsCaptain { get; set; } = false;
        public bool IsViceCaptain { get; set; } = false;
        public bool IsWicketKeeper { get; set; } = false;
        public DateTime OnBoardingDate { get; set; }
        public DateTime? OffBoardingDate { get; set; } = null;
    }
}
