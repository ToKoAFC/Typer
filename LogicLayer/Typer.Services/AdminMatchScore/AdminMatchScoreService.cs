using System.Linq;
using Typer.CoreModels.Models.MatchScore;
using Typer.Database.Access.Access.MatchScore;
using Typer.ViewModels.Common;
using Typer.ViewModels.Views.AdminMatchScore;

namespace Typer.Services.AdminMatchScore
{
    public class AdminMatchScoreService
    {
        private AdminMatchScoreAccess _adminMatchScoreAccess;

        public AdminMatchScoreService()
        {
            _adminMatchScoreAccess = new AdminMatchScoreAccess();
        }

        public VMAdminMatchScoreIndex GetAdminMatchScoreIndex()
        {
            var coreMatchScores = _adminMatchScoreAccess.GetScores();
            var vmMatchScores = coreMatchScores.Select(x => new VMMatchScore
            {
                AwayTeamGoals = x.AwayTeamGoals,
                HomeTeamGoals = x.HomeTeamGoals,
                AwayTeamName = x.AwayTeamName,
                HomeTeamName = x.HomeTeamName,
                MatchId = x.MatchId,
                MatchScoreId = x.MatchScoreId
            }).ToList();

            var model = new VMAdminMatchScoreIndex
            {
                Scores = vmMatchScores
            };
            return model;
        }

        public void AddScoreMatch(VMAdminMatchScoreCreate vmMatchScore)
        {
            var coreModel = new CoreNewMatchScore
            {
                AwayTeamGoals = vmMatchScore.AwayTeamGoals,
                HomeTeamGoals = vmMatchScore.HomeTeamGoals,
                MatchId = vmMatchScore.MatchId,
                MatchScoreId = vmMatchScore.MatchScoreId
            };
            _adminMatchScoreAccess.AddMatchScore(coreModel);
        }
    }
}
