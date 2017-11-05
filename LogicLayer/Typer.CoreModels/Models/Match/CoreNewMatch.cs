using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.ViewModels.AdminMatch;

namespace Typer.CoreModels.Models.Match
{
    public class CoreNewMatch
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int MatchweekId { get; set; }
        public int SeasonId { get; set; }
        public DateTime MatchDate { get; set; }
    }
}
