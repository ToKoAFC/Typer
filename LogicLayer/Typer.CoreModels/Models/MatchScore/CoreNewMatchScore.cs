using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typer.CoreModels.Models.MatchScore
{
    public class CoreNewMatchScore
    {
        public int MatchScoreId { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public int MatchId { get; set; }
    }
}
