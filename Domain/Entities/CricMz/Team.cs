using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class Team : IEntity
    {
        public string ID { get; set; } = string.Empty;
        public string TeamName { get; set; } = string.Empty;
        public string BoardName { get; set; } = string.Empty;
        public string OrganizationName { get; set; } = string.Empty;
        public string OwnersName { get; set; } = string.Empty;
        public bool IsInternational { get; set; } = true;
        public bool IsNational { get; set; } = true;
        public bool IsDomestic { get; set; } = true;
        public bool IsFranchise { get; set; } = true;
        public bool IsLocal { get; set; } = true;
        public bool IsSGI { get; set; } = true; // Street-Gully-Indoor


        //[Squard] , [Playing XI] , [Bench] , [Batting] , [Bowling]
    }
}
