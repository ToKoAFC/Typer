using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Typer.ViewModels.Views.Statisctic;

namespace Typer.Services.Interfaces
{
    public interface IStatisticService
    {
        List<VMUserStatistic> GetUserStatistics(string userId, int seasonId);
        SelectList GetSeasonSelectList();
    }
}
