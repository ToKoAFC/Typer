using System.Collections.Generic;
using Typer.ViewModels.Common;
using Typer.ViewModels.Views.Typer;

namespace Typer.Services.Interfaces
{
    public interface ITyperService
    {
        List<VMMatchPrediction> GetTyperIndexMatches(string user);
        void ChangeMatchPredictions(VMTyperIndex model, string userId);
    }
}
