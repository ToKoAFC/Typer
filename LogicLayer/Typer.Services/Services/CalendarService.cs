using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Typer.CoreModels.Models.Season;
using Typer.Database.Access;
using Typer.Services.Interfaces;
using Typer.ViewModels.Common;
using Typer.ViewModels.Views.Calendar;

namespace Typer.Services.Calendar
{
    public class CalendarService : ICalendarService 
    {
        private readonly IMatchAccess _matchAccess;
        private readonly ISeasonAccess _seasonAccess;

        public CalendarService(IMatchAccess matchAccess, ISeasonAccess seasonAccess)
        {
            _matchAccess = matchAccess;
            _seasonAccess = seasonAccess;
        }

        public VMCalendarIndex GetCalendarIndex(int seasonId)
        {
            var matches = _matchAccess.GetMatches(new CoreSeason { SeasonId = seasonId }).Select(x => new VMMatch
            {
                AwayTeamGoals = x.AwayTeamGoals,
                HomeTeamGoals = x.HomeTeamGoals,
                AwayTeamName = x.AwayTeamName,
                HomeTeamName = x.HomeTeamName,
                MatchId = x.MatchId,
                MatchDate = x.MatchDate
            }).ToList();
            return new VMCalendarIndex { Matches = matches };
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
