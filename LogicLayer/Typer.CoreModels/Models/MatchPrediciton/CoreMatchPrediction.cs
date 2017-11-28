using System;
using Typer.CoreModels.Models.Match;

namespace Typer.CoreModels.Models.MatchPrediction
{
    public class CoreMatchPrediction
    {
        public int MatchPredictionId { get; set; }
        public int? HomeTeamGoals { get; set; }
        public int? AwayTeamGoals { get; set; }
        public int MatchId { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public DateTime MatchDate { get; set; }
        public string UserId { get; set; }
        public int? Points { get; set; }
    }
}
