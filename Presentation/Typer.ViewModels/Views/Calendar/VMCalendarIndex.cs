using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Typer.ViewModels.Common;

namespace Typer.ViewModels.Views.Calendar
{
    public class VMCalendarIndex
    {
        public SelectList SelectListSeasons { get; set; }
        public int SeasonId { get; set; }
        public List<VMMatch> Matches { get; set; }
    }
}
