using System.Linq;
using Typer.CoreModels.Models.MatchScore;
using Typer.Database.Access;
using Typer.Services.Interfaces;
using Typer.ViewModels.Common;
using Typer.ViewModels.Views.AdminMatchScore;

namespace Typer.Services.AdminMatchScore
{
    public class AdminMatchScoreService : IAdminMatchScoreService
    {
        private readonly IMatchScoreAccess _matchScoreAccess;

        public AdminMatchScoreService(IMatchScoreAccess matchScoreAccess)
        {
            _matchScoreAccess = matchScoreAccess;
        }
        
        public VMAdminMatchScoreIndex GetAdminMatchScoreIndex()
        {
            var coreMatchScores = _matchScoreAccess.GetScores();
            var vmMatchScores = coreMatchScores.Select(x => new VMMatchScore
            {
                AwayTeamGoals = x.AwayTeamGoals,
                HomeTeamGoals = x.HomeTeamGoals,
                AwayTeamName = x.AwayTeamName,
                HomeTeamName = x.HomeTeamName,
                MatchId = x.MatchId,
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
                _matchScoreAccess.AddMatchScore(new CoreNewMatchScore
                {
                    AwayTeamGoals = score.AwayTeamGoals,
                    HomeTeamGoals = score.HomeTeamGoals,
                    MatchId = score.MatchId,
                });
            }
        }
    }
}
