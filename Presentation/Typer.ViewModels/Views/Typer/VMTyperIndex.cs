using System.Collections.Generic;
using System.Web.Mvc;
using Typer.ViewModels.Common;

namespace Typer.ViewModels.Views.Typer
{
    public class VMTyperIndex
    {
        public SelectList Seasons { get; set; }
        public SelectList Matchweeks { get; set; }
        public int SeasonId { get; set; }
        public int MatchweekId { get; set; }
        public List<VMMatch> Matches { get; set; }
    }
}
