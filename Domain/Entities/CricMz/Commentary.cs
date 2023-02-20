using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class Commentary
    {
        public string ID { get; set; } = string.Empty;
        public string ProfileID { get; set; } = string.Empty;
        public string CommentatorID { get; set; } = string.Empty;
        public string BallID { get; set; } = string.Empty;
    }
}
