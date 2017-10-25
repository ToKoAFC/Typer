using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typer.CoreModels.Models.Matchweek
{
    public class CoreNewMatchweek
    {
        public CoreNewMatchweek(string matchweekName)
        {
            MatchweekName = matchweekName;
        }
        public string MatchweekName { get; set; }
    }
}
