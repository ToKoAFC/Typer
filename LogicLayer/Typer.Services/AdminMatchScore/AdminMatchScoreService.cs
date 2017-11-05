using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.CoreModels.Models.MatchScore;
using Typer.Database.Access.Access.MatchScore;
using Typer.ViewModels.AdminMatchScore;

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
            var vmMatchScores = coreMatchScores.Select(x => new VMAdminMatchScoreIndexScore
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

        public void AddScoreMatch(VMAdminMatchScoreCreateMatchScore vmMatchScore)
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
