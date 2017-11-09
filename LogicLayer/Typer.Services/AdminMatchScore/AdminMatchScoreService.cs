using System.Linq;
using Typer.CoreModels.Models.MatchScore;
using Typer.Database.Access.MatchScore;
using Typer.ViewModels.Common;
using Typer.ViewModels.Views.AdminMatchScore;

namespace Typer.Services.AdminMatchScore
{
    public class AdminMatchScoreService
    {
        public AdminMatchScoreAccess _adminMatchScoreAccess { get; set; }
        
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

       
        public void AddScoreMatch(VMAdminMatchScoreIndex vmMatchScore)
        {
            foreach (var score in vmMatchScore.Scores)
            {
                _adminMatchScoreAccess.AddMatchScore(new CoreNewMatchScore
                {
                    AwayTeamGoals = score.AwayTeamGoals,
                    HomeTeamGoals = score.HomeTeamGoals,
                    MatchId = score.MatchId,
                });
            }
        }
    }
}
