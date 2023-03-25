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

        public BasicInfo TournamentInfo { get; set; } = new BasicInfo();
        public BasicInfo SeriesInfo { get; set; } = new BasicInfo();
        public BasicInfo StadiumInfo { get; set; } = new BasicInfo();
        public BasicInfo FirstUmpireInfo { get; set; } = new BasicInfo();
        public BasicInfo SecondUmpireInfo { get; set; } = new BasicInfo();
        public BasicInfo TvUmpireInfo { get; set; } = new BasicInfo();
        public BasicInfo MatchRefreeInfo { get; set; } = new BasicInfo();

        public Squad HomeTeam { get; set; } = new Squad();
        public Squad AwayTeam { get; set; } = new Squad();

        public BasicInfo ManOfMatch { get; set; } = new BasicInfo();
        public BasicInfo ManOfSeries { get; set; } = new BasicInfo();
        public List<Award> OtherRewards { get; set; }

        public string TossWinTeamID { get; set; } = string.Empty; // Team ID
        public string WinningTeamID { get; set; } = string.Empty; // Team ID
        public string TossDecition { get; set; } = string.Empty; // 'Bat' / 'Bowl' or 'Fielding'
        public string WeatherCondition { get; set; } = string.Empty;
        public string MatchResult { get; set; } = string.Empty;
        public string MatchWinsBy { get; set; } = string.Empty; // Runs / Wickets
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
}
