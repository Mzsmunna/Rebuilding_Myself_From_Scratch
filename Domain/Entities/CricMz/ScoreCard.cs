using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class ScoreCard : IEntity
    {
        public int HomeTeam { get; set; } = 0;
    }
}
