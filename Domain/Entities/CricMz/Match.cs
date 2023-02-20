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
        public BasicInfo TournamentInfo { get; set; } = new BasicInfo();
        public BasicInfo SeriesInfo { get; set; } = new BasicInfo();
        public BasicInfo StadiumInfo { get; set; } = new BasicInfo();
        public MatchFormats MatchFormats { get; set; }
        public MatchTypes MatchTypes { get; set; }
		public BasicInfo HomeTeamInfo { get; set; } = new BasicInfo();
        public BasicInfo AwayTeamInfo { get; set; } = new BasicInfo();
        public BasicInfo FirstUmpireInfo { get; set; } = new BasicInfo();
        public BasicInfo SecondUmpireInfo { get; set; } = new BasicInfo();
        public BasicInfo ThirdUmpireInfo { get; set; } = new BasicInfo();
        public BasicInfo RefreeInfo { get; set; } = new BasicInfo();
        public string TossWin { get; set; } = string.Empty; // 'HomeTeam' / 'AwayTeam'
        public string WinningTeam { get; set; } = string.Empty; // 'HomeTeam' / 'AwayTeam'
        public string TossDecition { get; set; } = string.Empty; // 'Bat' / 'Bowl' or 'Fielding'
        public string WeatherCondition { get; set; } = string.Empty;
        public bool IsInterruptedByRain { get; set; }
        public bool IsMatchAbandoned { get; set; }
        public bool IsMatchStarted { get; set; }
        public bool IsMatchFinished { get; set; }
        public bool IsMatchTied { get; set; }
        public DateTime MatchStartTime { get; set; }


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
}
