using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CricMz
{
    public class Score : IEntity
    {
        public BasicInfo TeamInfo { get; set; } = new BasicInfo();
        public Scorer? HighestScorer { get; set; } = null;
        public Scorer? HighestWicketTaker { get; set; } = null;
        public bool IsWinner { get; set; } = false;
        public int Innings { get; set; } = 1; // TEST_MAX => 4, REST_MAX => 2
        public int Target { get; set; } = 0;
        public double CurrentRunRate { get; set; } = 0;
        public double RequireRunRate { get; set; } = 0;
        public int Runs { get; set; } = 0;
        public int Wickets { get; set; } = 0;
        public int ExtraRuns { get; set; } = 0;
        public int WideRuns { get; set; } = 0;
        public int ByeRuns { get; set; } = 0;
        public int LegByeRuns { get; set; } = 0;
        public int BonusRuns { get; set; } = 0;
        public int Dots { get; set; } = 0;
        public int Ones { get; set; } = 0;
        public int Twos { get; set; } = 0;
        public int Threes { get; set; } = 0;
        public int Fours { get; set; } = 0;
        public int Fives { get; set; } = 0;
        public int Sixes { get; set; } = 0;
        public int Sevens { get; set; } = 0;
        public int Balls { get; set; } = 0;
        public int NoBalls { get; set; } = 0;
        public int WideBalls { get; set; } = 0;
        public int RemainingBalls { get; set; } = 0;
        public int Over { get; set; } = 0;
        public int OverBallNo { get; set; } = 0; // Max =  6 / 5
    }

    public class Scorer
    {
        public Identity PlayerInfo { get; set; } = new Identity();
        public int RunScored { get; set; } = 0;
        public int BallPlayed { get; set; } = 0;
        public int RunGiven { get; set; } = 0;
        public int BallDelivered { get; set; } = 0;
        public int WicketTaken { get; set; } = 0;
        public int CatchTaken { get; set; } = 0;
        public int RunOuts { get; set; } = 0;
        public int Stumped { get; set; } = 0;
    }
}
