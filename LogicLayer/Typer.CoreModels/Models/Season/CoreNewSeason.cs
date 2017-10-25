using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typer.CoreModels.Models.Season
{
    public class CoreNewSeason
    {
        public CoreNewSeason(int startYear, int endYear)
        {
            StartYear = startYear;
            EndYear = endYear;
        }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
    }
}
