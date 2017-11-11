using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typer.CoreModels.Models.Score
{
    public class CoreMatchScore
    {
        public int MatchScoreId { get; set; }
        public string HomeTeamName { get; set; }
        public int? HomeTeamGoals { get; set; }
        public string AwayTeamName { get; set; }
        public int? AwayTeamGoals { get; set; }
        public int MatchId { get; set; }
    }
}
