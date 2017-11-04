using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Typer.ViewModels.AdminMatch
{
    public class VMAdminMatchCreateMatch
    {
        public SelectList Seasons { get; set; }
        public SelectList Matchweeks { get; set; }
        public SelectList Teams { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int MatchweekId { get; set; }
        public int SeasonId { get; set; }
        public DateTime MatchDate { get; set; }
    }
}
