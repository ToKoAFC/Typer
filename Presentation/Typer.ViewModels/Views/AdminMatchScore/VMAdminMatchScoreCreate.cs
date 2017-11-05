using Typer.ViewModels.Views.AdminMatch;

namespace Typer.ViewModels.Views.AdminMatchScore
{
    public class VMAdminMatchScoreCreate
    {
        public int MatchScoreId { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
        public int MatchId { get; set; }
        public VMAdminMatchIndex Matches { get; set; }
    }
}
