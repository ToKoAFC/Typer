using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.ViewModels.AdminMatch;

namespace Typer.ViewModels.AdminMatchScore
{
    public class VMAdminMatchScoreCreateMatchScore
    {
        public int MatchScoreId { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
        public int MatchId { get; set; }
        public VMAdminMatchIndex Matches { get; set; }
    }
}
