using System.Collections.Generic;
using System.Linq;
using Typer.CoreModels.Models;
using Typer.CoreModels.Models.MatchPrediction;
using Typer.Database.Migrations;

namespace Typer.Database.Access
{
    public class MatchPredictionAccess : IMatchPredictionAccess
    {
        private readonly TyperContext _context;
        public MatchPredictionAccess()
        {
            _context = new TyperContext();
        }

        public List<CoreMatchPrediction> GetMatchPredictions(string userId)
        {
            throw new System.NotImplementedException();
        }       
    }
}
