using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Typer.Database.Access;
using Typer.Services.Interfaces;
using Typer.ViewModels.Views.Statisctic;

namespace Typer.Services.Statistic
{
    public class StatisticService : IStatisticService
    {
        private readonly ISeasonAccess _seasonAccess;
        private readonly IMatchPredictionAccess _matchPredictionAccess;

        public StatisticService( ISeasonAccess seasonAccess, IMatchPredictionAccess matchPredictionAccess)
        {
            _seasonAccess = seasonAccess;
            _matchPredictionAccess = matchPredictionAccess;
        }

        public List<VMUserStatistic> GetUserStatistics(int seasonId)
        {
            return _matchPredictionAccess.GetUsetStatistics(seasonId).Select(x => new VMUserStatistic
            {
                Username = x.Username,
                UserPoints = x.UserPoints
            }).ToList();
        }

        public SelectList GetSeasonSelectList()
        {
            var coreSesons = _seasonAccess.GetSeasons();
            var selectListItems = coreSesons.Select(x => new SelectListItem
            {
                Value = x.SeasonId.ToString(),
                Text = $"{x.StartYear}/{x.EndYear}"
            });
            return new SelectList(selectListItems, "Value", "Text");
        }
    }
}
