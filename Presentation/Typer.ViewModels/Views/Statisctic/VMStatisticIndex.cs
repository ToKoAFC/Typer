using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Typer.ViewModels.Views.Statisctic
{
    public class VMStatisticIndex
    {
        public List<VMUserStatistic> UserStatistics { get; set; }
        public SelectList Seasons { get; set; }
        public int SeasonId { get; set; }
    }
}
