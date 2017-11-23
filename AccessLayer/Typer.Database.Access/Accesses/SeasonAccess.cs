using System;
using System.Collections.Generic;
using System.Linq;
using Typer.CoreModels.Models.Season;
using Typer.Database.Migrations;
using Typer.Database.Models;

namespace Typer.Database.Access
{
    public class SeasonAccess : ISeasonAccess
    {
        private TyperContext _context;
        public SeasonAccess()
        {
            _context = new TyperContext();
        }

        public List<CoreSeason> GetSeasons()
        {
            return _context.DbSeasons.Select(x => new CoreSeason { SeasonId = x.SeasonId, EndYear = x.YearEnd, StartYear = x.YearStart })
                .OrderByDescending(x => x.StartYear).ToList();
        }

        public void AddSeason(CoreNewSeason coreSeason)
        {
            var dbSeason = new DbSeason
            {
                YearStart = coreSeason.StartYear,
                YearEnd = coreSeason.EndYear
            };
            _context.DbSeasons.Add(dbSeason);
            _context.SaveChanges();
        }
    }
}