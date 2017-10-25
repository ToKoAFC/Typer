using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.CoreModels.Models.Season;
using Typer.Database.Migrations;
using Typer.Database.Models;

namespace Typer.Database.Access.Access.Season
{
    public class AdminSeasonAcess
    {
        private TyperContext _context;
        public AdminSeasonAcess()
        {
            _context = new TyperContext();
        }

        public List<CoreSeason> GetSeasons()
        {
            return _context.DbSeasons.Select(x => new CoreSeason { SeasonId = x.SeasonId, EndYear = x.EndYear, StartYear = x.StartYear }).ToList();
        }

        public void AddSeason(CoreNewSeason coreSeason)
        {
            var dbSeason = new DbSeason
            {
                StartYear = coreSeason.StartYear,
                EndYear = coreSeason.EndYear
            };
            _context.DbSeasons.Add(dbSeason);
            _context.SaveChanges();
        }
    }
}
