using System;

namespace Typer.CoreModels.Models.Match
{
    public class CoreNewMatch
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int MatchweekId { get; set; }
        public int SeasonId { get; set; }
        public DateTime MatchDate { get; set; }
    }
}
