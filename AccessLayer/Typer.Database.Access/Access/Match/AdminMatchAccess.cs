﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.CoreModels.Models.Match;
using Typer.Database.Migrations;
using Typer.Database.Models;

namespace Typer.Database.Access.Access.Match
{
    public class AdminMatchAccess
    {
        private TyperContext _context;
        public AdminMatchAccess()
        {
            _context = new TyperContext();
        }

        public List<CoreMatch> GetMatches()
        {
            return _context.DbMatchs.Select(x => new CoreMatch
            {
                AwayTeamId = x.AwayTeamId,
                HomeTeamId = x.HomeTeamId,
                MatchweekId = x.MatchweekId,
                AwayTeamName = x.AwayTeam.TeamName,
                HomeTeamName = x.HomeTeam.TeamName
            }).ToList();
        }

        public void CreateMatch(CoreNewMatch coreMatch)
        {
            var dbMatch = new DbMatch
            {
                MatchweekId = coreMatch.MatchweekId,
                HomeTeamId = coreMatch.HomeTeamId,
                AwayTeamId = coreMatch.AwayTeamId
            };
            _context.DbMatchs.Add(dbMatch);
            _context.SaveChanges();
        }
    }
}
