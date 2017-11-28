using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typer.CoreModels.Models.MatchPrediciton
{
    public class CoreChangeMatchPrediction
    {
        public int MatchPredictionId { get; set; }
        public string UserId { get; set; }
        public int? HomeTeamGoals { get; set; }
        public int? AwayTeamGoals { get; set; }
        public int MatchId { get; set; }
    }

}
