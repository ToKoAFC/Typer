using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Typer.ViewModels.Typer
{
    public class VMTyperIndex
    {
        public SelectList Seasons { get; set; }
        public SelectList Matchweeks { get; set; }
        public int SeasonId { get; set; }
        public int MatchweekId { get; set; }
        public List<VMTyperIndexMatch> Matches { get; set; }
    }
}
