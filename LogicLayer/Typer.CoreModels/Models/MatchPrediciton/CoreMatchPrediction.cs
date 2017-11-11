using Typer.CoreModels.Models.Score;

namespace Typer.CoreModels.Models.MatchPrediction
{
    public class CoreMatchPrediction
    {
        public int MatchPredictionId { get; set; }
        public string UserId { get; set; }
        public CoreMatchScore MatchScore { get; set; }
    }
}
