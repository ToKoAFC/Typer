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
        private readonly IPointsAccess _pointsAccess;
        private readonly ISeasonAccess _seasonAccess;

        public StatisticService(IPointsAccess pointsAccess, ISeasonAccess seasonAccess)
        {
            _pointsAccess = pointsAccess;
            _seasonAccess = seasonAccess;
        }

        public List<VMUserStatistic> GetUserStatistics(string userId, int seasonId)
        {
            return _pointsAccess.GetUserStatistic(seasonId, userId).Select(x => new VMUserStatistic
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
